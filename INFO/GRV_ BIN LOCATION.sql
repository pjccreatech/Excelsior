

CREATE VIEW vw_XLSR_PurchaseOrdersForGRV
as
SELECT 
	i.AutoIndex, i.OrderNum, Vendor.Account, Vendor.Name, i.OrderDate, v.ulIDPOrdConfirmed
FROM Hertex.dbo.InvNum i
INNER JOIN Hertex.dbo.Vendor ON I.AccountID = Vendor.DCLink
LEFT JOIN Hertex.dbo._evInvNumUDFLink V ON V.AutoIndex = Vendor.DCLink
WHERE 
	(i.DocType = 5)
	AND (i.DocFlag = 1)
	AND NOT (i.AccountID = 1114) -- Cut Measure T??
	AND ((i.DocState = 1) OR (i.DocState = 3))
	-- FOLLOWING FILTER GET HANDLED IN APP
   --if not((vStaffID = 'vanessa') or (vStaffID = 'nicholas') or (vStaffID = 'charlene') or (vStaffID = 'nolen')) then --AND ulIDPOrdConfirmed = ''Confirmed''');
ORDER BY I.OrderNum desc

SELECT * FROM Hertex.dbo._evInvNumUDFLink
SELECT * FROM Hertex.dbo._bvInvNumUDF

select * from Hertex.dbo.Vendor where DCLink = 1114


select * from vw_XLSR_PurchaseOrdersForGRV

select * from _btblBINLocation
select * from _etblStockBinLocations
select * from _btblBINLocation
exec Hertex.dbo.SearchAllTables 'WHSDOC'
select cat from StkItem
select * from _etblStockDetails
select * from Hertex.dbo._etblStockCategories
WHERE cCategoryName IN 
(
'BBSDOC',
'TRSDOC',
'CRSDOC',
'RSSDOC',
'WHSDOC',
'DOC',
'SS001',
'MF001'
)


select * from HertexRollStk.dbo.tStoreName
update HertexRollStk.dbo.tStoreName set IsGRVBin = 2 where BinLocation in (

'TRSDOC')