
DECLARE 
	@theDate datetime = GETDATE()

SELECT 
	i.AutoIndex,
	xg.GrpAlias OrderType,				--???
	i.ordernum,
	CASE substring(c.Account, 1, 2) WHEN 'I-' THEN 'JHB' ELSE 'CPT' END AS Region,
	ISnULL(x.dtconfirm, i.OrderDate) OrderDate,
	c.Account,
	c.Name,
	i.DeliveryDate,
	ISNULL(d.Comment, '') AS Shipping,
	i.ucIDSOrdAgent,
	i.iProspectID AS BeingCut,			--lockin
	CAST(i.OrdTotIncl AS float) AS OrdTotIncl,
	i.dDTstamp
FROM Hertex.dbo._evInvNumUDFLink i
LEFT JOIN Hertex.dbo.Client c WITH(NOLOCK) ON c.DCLink = i.AccountID
LEFT JOIN Hertex.dbo.SalesRep s WITH(NOLOCK) ON s.idSalesRep = c.RepID
LEFT JOIN Hertex.dbo.DelTbl d WITH(NOLOCK) ON d.Counter = i.DelMethodID 
LEFT JOIN (select InvID, min(dtStamp) dtconfirm from Hertex.dbo.zz_InvNum_Confirmations WITH(NOLOCK) group by InvID) x  ON x.InvID = i.AutoIndex
INNER JOIN 
(
	SELECT 		
		x_l.iInvoiceID,	
		MAX(x_g.idGrpTbl) idGrpTbl
	FROM Hertex.dbo._btblInvoiceLines x_l
	LEFT JOIN Hertex.dbo._etblStockDetails x_s ON x_s.StockID = x_l.iStockCodeID
	LEFT JOIN Hertex.dbo.GrpTbl x_g ON x_g.idGrpTbl = x_s.GroupID
	INNER JOIN XR_MainStockGroups x_x ON x_x.GrpID = x_g.idGrpTbl
	WHERE x_l.fQuantity <> 0
	GROUP BY x_l.iInvoiceID
	HAVING  count(distinct(x_g.idGrpTbl)) = 1
) t ON t.iInvoiceID = i.AutoIndex
LEFT JOIN XR_MainStockGroups xg ON  xg.GrpID =  t.idGrpTbl
WHERE 
	(i.DocType = 4) 
	AND (i.DocState = 1 OR i.DocState = 3) 
	AND left(i.OrderNum,3)<>'soq'
	AND (ISNULL(i.ulIDSOrdConfirmed, '') = 'Confirmed') 
	AND (i.TaxInclusive = 0) 
	AND (i.DueDate <= @theDate) 
	--AND (_btblInvoiceLines.fQuantity <> 0) 
	--AND StkItem.Qty_On_Hand > 0
order by 1 desc
