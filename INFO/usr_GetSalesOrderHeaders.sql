

--ALTER                           procedure [dbo].[usr_GetSalesOrderHeaders]
-- usr_GetSalesOrderHeaders 1

DECLARE 
	@OrderStatus	integer = 1
-- exec usr_GetSalesOrderHeaders 1

-- exec usr_GetSalesOrderHeaders 1

declare 
@theDate datetime
set @theDate = GETDATE()
SELECT 
	DISTINCT 
		CASE substring(Client.Account, 1, 2) WHEN 'I-' THEN 'JHB' ELSE 'CPT' END AS Region, 
		InvNum.OrderNum, 
		isnull(vw_OrderConfirmedDateStamp.ConfirmedDate,OrderDate) AS OrderDate, 
		Client.Account, 
		Client.Name, 
		InvNum.DeliveryDate, 
		InvNum.AutoIndex, 
		ISNULL(DelTbl.Comment, '') AS Shipping, 
		CAST('' AS varchar(20)) AS OrderType, 
		ISNULL(InvNum.OrderStatusID,3) AS OrderStatus, 
		InvNum.ucIDSOrdAgent, 
		InvNum.iProspectID AS BeingCut, 
		CAST(InvNum.OrdTotIncl AS float) AS OrdTotIncl, 
		CAST(1 AS bit) AS CreditApproved, 
		InvNum.dDTstamp, 
		SalesRep.Code AS RepCode
into #temp
FROM SalesRep WITH (NOLOCK) INNER JOIN
InvNum WITH (NOLOCK) INNER JOIN
Client WITH (NOLOCK) ON InvNum.AccountID = Client.DCLink INNER JOIN
_btblInvoiceLines WITH (NOLOCK) ON InvNum.AutoIndex = _btblInvoiceLines.iInvoiceID INNER JOIN
StkItem WITH (NOLOCK) ON _btblInvoiceLines.iStockCodeID = StkItem.StockLink INNER JOIN
zz_Omni_RollSOH WITH (NOLOCK) ON StkItem.Code = zz_Omni_RollSOH.stockcode COLLATE Latin1_General_CI_AS LEFT OUTER JOIN
DelTbl WITH (NOLOCK) ON InvNum.DelMethodID = DelTbl.Counter ON SalesRep.idSalesRep = Client.RepID LEFT OUTER JOIN
vw_OrderConfirmedDateStamp WITH (NOLOCK) ON InvNum.OrderNum = vw_OrderConfirmedDateStamp.OrderNum
WHERE (InvNum.DocType = 4) AND (InvNum.DocState = 1 OR InvNum.DocState = 3) 
AND (ISNULL(InvNum.ulIDSOrdConfirmed, '') = 'Confirmed') 
AND (StkItem.ItemGroup IN ('001', '002', '003', '004', '005', '006', '007', '008','009','010', '011','012','013','014', '900','901','991','992')) 
AND (_btblInvoiceLines.fQuantity <> 0) 
AND (InvNum.TaxInclusive = 0) 
AND (InvNum.DueDate <= @theDate) 
and StkItem.Qty_On_Hand>0
and left(InvNum.OrderNum,3)<>'soq'
--and SalesRep.Code like '%X%'
-- Extract the CPT order type

select InvNum.OrderNum, 
cast('Y' as char(1)) Wallpaper, -- 1 
cast('' as char(1)) Samples,-- 2&3 
cast('' as char(1)) Rugs, --4
cast('' as char(1)) Textile, --5
cast('' as char(1)) BedBath, --6
cast('' as char(1)) Illumination, -- 7
cast('' as char(1)) Entertaining, --8
cast('' as char(1)) Furniture, --9
cast('' as char(1)) Decorative, -- 10
cast('' as char(1)) TradehausRugs, --11
cast('' as char(1)) TradehausFurn, --13
cast('' as char(1)) TradehausWallArt --14
into #OrdType
from InvNum  with (NOLOCK), _btblInvoiceLines  with (NOLOCK), StkItem  with (NOLOCK)
where (InvNum.DocType = 4) AND (InvNum.DocState = 1 OR InvNum.DocState = 3)
and iInvoiceId = Autoindex
and iStockCodeID = StkItem.StockLink
and StkItem.ItemGroup='001' --wallpaper

insert into #OrdType
select InvNum.OrderNum, 
'', 
'Y',
'',
'',
'',
'',
'',
'',
'',
'',
'',
''
from InvNum with (NOLOCK), _btblInvoiceLines with (NOLOCK), StkItem with (NOLOCK)
where (InvNum.DocType = 4) AND (InvNum.DocState = 1 OR InvNum.DocState = 3)
and iInvoiceId = Autoindex
and iStockCodeID = StkItem.StockLink
and StkItem.ItemGroup in ('002','003')--samples

insert into #OrdType
select InvNum.OrderNum, 
'', 
'',
'Y',
'',
'',
'',
'',
'',
'',
'',
'',
''
from InvNum with (NOLOCK), _btblInvoiceLines with (NOLOCK), StkItem with (NOLOCK)
where (InvNum.DocType = 4) AND (InvNum.DocState = 1 OR InvNum.DocState = 3)
and iInvoiceId = Autoindex
and iStockCodeID = StkItem.StockLink
and StkItem.ItemGroup='004'--Rugs

insert into #OrdType
select InvNum.OrderNum, 
'', 
'',
'',
'Y',
'',
'',
'',
'',
'',
'',
'',
''
from InvNum with (NOLOCK), _btblInvoiceLines with (NOLOCK), StkItem with (NOLOCK)
where (InvNum.DocType = 4) AND (InvNum.DocState = 1 OR InvNum.DocState = 3)
and iInvoiceId = Autoindex
and iStockCodeID = StkItem.StockLink
and StkItem.ItemGroup='005'--textile

insert into #OrdType
select InvNum.OrderNum, 
'', 
'',
'',
'',
'Y',
'',
'',
'',
'',
'',
'',
''
from InvNum with (NOLOCK), _btblInvoiceLines with (NOLOCK), StkItem with (NOLOCK)
where (InvNum.DocType = 4) AND (InvNum.DocState = 1 OR InvNum.DocState = 3)
and iInvoiceId = Autoindex
and iStockCodeID = StkItem.StockLink
and StkItem.ItemGroup='006'--Bedroom / Bathroom

insert into #OrdType
select InvNum.OrderNum, 
'', 
'',
'',
'',
'',
'Y',
'',
'',
'',
'',
'',
''
from InvNum with (NOLOCK), _btblInvoiceLines with (NOLOCK), StkItem with (NOLOCK)
where (InvNum.DocType = 4) AND (InvNum.DocState = 1 OR InvNum.DocState = 3)
and iInvoiceId = Autoindex
and iStockCodeID = StkItem.StockLink
and StkItem.ItemGroup in ('007')--illum

insert into #OrdType
select InvNum.OrderNum, 
'', 
'',
'',
'',
'',
'',
'Y',
'',
'',
'',
'',
''
from InvNum with (NOLOCK), _btblInvoiceLines with (NOLOCK), StkItem with (NOLOCK)
where (InvNum.DocType = 4) AND (InvNum.DocState = 1 OR InvNum.DocState = 3)
and iInvoiceId = Autoindex
and iStockCodeID = StkItem.StockLink
and StkItem.ItemGroup='008'--Entertaining

insert into #OrdType
select InvNum.OrderNum, 
'', 
'',
'',
'',
'',
'',
'',
'Y',
'',
'',
'',
''
from InvNum with (NOLOCK), _btblInvoiceLines with (NOLOCK), StkItem with (NOLOCK)
where (InvNum.DocType = 4) AND (InvNum.DocState = 1 OR InvNum.DocState = 3)
and iInvoiceId = Autoindex
and iStockCodeID = StkItem.StockLink
and StkItem.ItemGroup='009'--Decorative

insert into #OrdType
select InvNum.OrderNum, 
'', 
'',
'',
'',
'',
'',
'',
'',
'Y',
'',
'',
''
from InvNum with (NOLOCK), _btblInvoiceLines with (NOLOCK), StkItem with (NOLOCK)
where (InvNum.DocType = 4) AND (InvNum.DocState = 1 OR InvNum.DocState = 3)
and iInvoiceId = Autoindex
and iStockCodeID = StkItem.StockLink
and StkItem.ItemGroup='010'--Decorative

insert into #OrdType
select InvNum.OrderNum, 
'', 
'',
'',
'',
'',
'',
'',
'',
'',
'Y',
'',
''
from InvNum with (NOLOCK), _btblInvoiceLines with (NOLOCK), StkItem with (NOLOCK)
where (InvNum.DocType = 4) AND (InvNum.DocState = 1 OR InvNum.DocState = 3)
and iInvoiceId = Autoindex
and iStockCodeID = StkItem.StockLink
and StkItem.ItemGroup='011'--TradehausRugs

insert into #OrdType
select InvNum.OrderNum, 
'', 
'',
'',
'',
'',
'',
'',
'',
'',
'',
'Y',
''
from InvNum with (NOLOCK), _btblInvoiceLines with (NOLOCK), StkItem with (NOLOCK)
where (InvNum.DocType = 4) AND (InvNum.DocState = 1 OR InvNum.DocState = 3)
and iInvoiceId = Autoindex
and iStockCodeID = StkItem.StockLink
and StkItem.ItemGroup='013'--Tradehaus furn

insert into #OrdType
select InvNum.OrderNum, 
'', 
'',
'',
'',
'',
'',
'',
'',
'',
'',
'',
'Y'
from InvNum with (NOLOCK), _btblInvoiceLines with (NOLOCK), StkItem with (NOLOCK)
where (InvNum.DocType = 4) AND (InvNum.DocState = 1 OR InvNum.DocState = 3)
and iInvoiceId = Autoindex
and iStockCodeID = StkItem.StockLink
and StkItem.ItemGroup='014'--Tradehaus wall art



--Convert it into a crosstab table
select Max(OrderNum) OrderNum,
Max(Wallpaper) Wallpaper,
Max(Samples) Samples,
Max(Rugs) Rugs,
Max(Textile) Textile,
Max(BedBath) BedBath,
MAX(Illumination) Illumination,
MAX(Entertaining) Entertaining,
MAX(Furniture) Furniture,
MAX(Decorative) Decorative,
MAX(TradehausRugs) TradehausRugs,
MAX(TradehausFurn) TradehausFurn,
MAX(TradehausWallArt) TradehausWallArt
into #OrdTypeSum
from #OrdType
group by OrderNum
order by 2 desc
--Update the main order table with the type that it is
update #Temp
set OrderType='Mixed'
update #Temp
set OrderType='Wallpaper'
from #temp, #OrdTypeSum
where #temp.OrderNum=#OrdTypeSum.OrderNum
and Wallpaper='Y' and Samples='' and Rugs='' and Textile = '' and BedBath = '' and Illumination = '' and Entertaining = '' 
and Furniture = '' and Decorative = '' and TradehausRugs = '' and TradehausFurn = '' and TradehausWallArt = ''

update #Temp
set OrderType='Samples'
from #temp, #OrdTypeSum
where #temp.OrderNum=#OrdTypeSum.OrderNum
and Wallpaper='' and Samples='Y' and Rugs='' and Textile = '' and BedBath = '' and Illumination = '' and Entertaining = '' 
and Furniture = '' and Decorative = '' and TradehausRugs = '' and TradehausFurn = '' and TradehausWallArt = ''

update #Temp
set OrderType='Rugs'
from #temp, #OrdTypeSum
where #temp.OrderNum=#OrdTypeSum.OrderNum
and Wallpaper='' and Samples='' and Rugs='Y' and Textile = '' and BedBath = '' and Illumination = '' and Entertaining = '' 
and Furniture = '' and Decorative = '' and TradehausRugs = '' and TradehausFurn = '' and TradehausWallArt = ''

update #Temp
set OrderType='Textile'
from #temp, #OrdTypeSum
where #temp.OrderNum=#OrdTypeSum.OrderNum
and Wallpaper='' and Samples='' and Rugs='' and Textile = 'Y' and BedBath = '' and Illumination = '' and Entertaining = '' 
and Furniture = '' and Decorative = '' and TradehausRugs = '' and TradehausFurn = '' and TradehausWallArt = ''

update #Temp
set OrderType='BedBath'
from #temp, #OrdTypeSum
where #temp.OrderNum=#OrdTypeSum.OrderNum
and Wallpaper='' and Samples='' and Rugs='' and Textile = '' and BedBath = 'Y' and Illumination = '' and Entertaining = '' 
and Furniture = '' and Decorative = '' and TradehausRugs = '' and TradehausFurn = '' and TradehausWallArt = ''

update #Temp
set OrderType='Illumination'
from #temp, #OrdTypeSum
where #temp.OrderNum=#OrdTypeSum.OrderNum
and Wallpaper='' and Samples='' and Rugs='' and Textile = '' and BedBath = '' and Illumination = 'Y' and Entertaining = '' 
and Furniture = '' and Decorative = '' and TradehausRugs = '' and TradehausFurn = '' and TradehausWallArt = ''

update #Temp
set OrderType='Entertain'
from #temp, #OrdTypeSum
where #temp.OrderNum=#OrdTypeSum.OrderNum
and Wallpaper='' and Samples='' and Rugs='' and Textile = '' and BedBath = '' and Illumination = '' and Entertaining = 'Y' 
and Furniture = '' and Decorative = '' and TradehausRugs = '' and TradehausFurn = '' and TradehausWallArt = ''

update #Temp
set OrderType='Furniture'
from #temp, #OrdTypeSum
where #temp.OrderNum=#OrdTypeSum.OrderNum
and Wallpaper='' and Samples='' and Rugs='' and Textile = '' and BedBath = '' and Illumination = '' and Entertaining = '' 
and Furniture = 'Y' and Decorative = '' and TradehausRugs = '' and TradehausFurn = '' and TradehausWallArt = ''

update #Temp
set OrderType='Decorative'
from #temp, #OrdTypeSum
where #temp.OrderNum=#OrdTypeSum.OrderNum
and Wallpaper='' and Samples='' and Rugs='' and Textile = '' and BedBath = '' and Illumination = '' and Entertaining = '' 
and Furniture = '' and Decorative = 'Y' and TradehausRugs = '' and TradehausFurn = '' and TradehausWallArt = ''

update #Temp
set OrderType='Rugs'
from #temp, #OrdTypeSum
where #temp.OrderNum=#OrdTypeSum.OrderNum
and Wallpaper='' and Samples='' and Rugs='' and Textile = '' and BedBath = '' and Illumination = '' and Entertaining = '' 
and Furniture = '' and Decorative = '' and TradehausRugs = 'Y' and TradehausFurn = '' and TradehausWallArt = ''

update #Temp
set OrderType='Furniture'
from #temp, #OrdTypeSum
where #temp.OrderNum=#OrdTypeSum.OrderNum
and Wallpaper='' and Samples='' and Rugs='' and Textile = '' and BedBath = '' and Illumination = '' and Entertaining = '' 
and Furniture = '' and Decorative = '' and TradehausRugs = '' and TradehausFurn = 'Y' and TradehausWallArt = ''

update #Temp
set OrderType='Wall Art'
from #temp, #OrdTypeSum
where #temp.OrderNum=#OrdTypeSum.OrderNum
and Wallpaper='' and Samples='' and Rugs='' and Textile = '' and BedBath = '' and Illumination = '' and Entertaining = '' 
and Furniture = '' and Decorative = '' and TradehausRugs = '' and TradehausFurn = '' and TradehausWallArt = 'Y'


if @OrderStatus = 1
	select * 
	from #temp
	ORDER BY 3 desc, 2 desc
else
	select * 
	from #temp
	where OrderStatus=@OrderStatus
	or OrderStatus=0
	ORDER BY 3 desc, 2 desc




-- usr_GetSalesOrderHeaders 1
drop table #temp
drop table #OrdType
drop table #OrdTypeSum








GO


