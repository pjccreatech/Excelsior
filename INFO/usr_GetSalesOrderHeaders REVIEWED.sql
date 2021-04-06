
DECLARE 
	@theDate datetime = GETDATE()

SELECT 
	i.OrderNum,
	CASE substring(c.Account, 1, 2) WHEN 'I-' THEN 'JHB' ELSE 'CPT' END AS Region,
	ISNULL(t2.ConfirmedDate, i.OrderDate) OrderDate,
	c.Account,
	c.Name,
	i.DeliveryDate,
	ISNULL(d.Comment, '') AS Shipping,
	i.ucIDSOrdAgent,
	i.iProspectID AS BeingCut,			--lockin
	CAST(i.OrdTotIncl AS float) AS OrdTotIncl,
	i.dDTstamp,
	t1.iInvoiceID,
	a.GrpID, a.GrpCode, a.GrpDescription, 
	CASE 
		WHEN  a.GrpID IS NULL THEN 'Mixed'
		ELSE
			a.GrpAlias
	END 'OrderType'
FROM 
(
	SELECT 	
		DISTINCT x_l.iInvoiceID,	
		CASE 
			WHEN COUNT(DISTINCT(x_g.idGrpTbl)) = 1 THEN AVG( x_g.idGrpTbl)
			ELSE -1
		END idGrpTbl
	FROM Hertex.dbo._btblInvoiceLines x_l WITH(NOLOCK)
	LEFT JOIN Hertex.DBO._evInvNumUDFLink x_i WITH(NOLOCK) ON x_i.AutoIndex = x_l.iInvoiceID
	LEFT JOIN Hertex.dbo._etblStockDetails x_s WITH(NOLOCK) ON x_s.StockID = x_l.iStockCodeID
	LEFT JOIN Hertex.dbo._etblStockQtys x_q WITH(NOLOCK) ON x_q.StockID = x_l.iStockCodeID
	LEFT JOIN Hertex.dbo.GrpTbl x_g WITH(NOLOCK) ON x_g.idGrpTbl = x_s.GroupID
	INNER JOIN HertexRollStk.DBO.XR_MainStockGroups x_x WITH(NOLOCK) ON x_x.GrpID = x_g.idGrpTbl
	WHERE 
		(x_i.DocType = 4) 
		AND (x_i.DocState = 1 OR x_i.DocState = 3) 
		AND (ISNULL(x_i.ulIDSOrdConfirmed, '') = 'Confirmed') 
		AND (x_l.fQuantity <> 0) 
		AND (x_i.TaxInclusive = 0) 
		and x_q.QtyOnHand>0
		and left(x_i.OrderNum,3)<>'soq'		
		AND (x_g.idGrpTbl IN (SELECT idGrpTbl FROM HertexRollStk.dbo.XR_MainStockGroups) ) 
		AND (x_i.DueDate <= @theDate) 
	GROUP BY x_l.iInvoiceID
) t1	
LEFT JOIN HertexRollStk.DBO.XR_MainStockGroups a WITH(NOLOCK) ON a.GrpID = T1.idGrpTbl
LEFT JOIN Hertex.DBO._evInvNumUDFLink i WITH(NOLOCK) ON i.AutoIndex = t1.iInvoiceID
LEFT JOIN Hertex.dbo.Client c WITH(NOLOCK) ON c.DCLink = i.AccountID
LEFT JOIN Hertex.dbo.DelTbl d WITH(NOLOCK) ON d.Counter = i.DelMethodID 
LEFT JOIN Hertex.dbo.SalesRep s WITH(NOLOCK) ON s.idSalesRep = c.RepID
LEFT JOIN (SELECT OrderNum, min(dtStamp) ConfirmedDate from XR_InvNum_Confirmations WHERE ulIDSOrdConfirmed = 'Confirmed' GROUP BY OrderNum) t2 ON  t2.OrderNum = i.OrderNum
ORDER BY 
	OrderDate DESC,
	i.OrderNum DESC
