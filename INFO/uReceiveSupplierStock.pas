unit uReceiveSupplierStock;

interface

uses
   Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
   Dialogs, StdCtrls, ExtCtrls, Buttons, DB, dxmdaset, cxStyles,
   cxCustomData, cxGraphics, cxFilter, cxData, cxDataStorage, cxEdit,
   cxDBData, cxGridLevel, cxClasses, cxControls, cxGridCustomView,
   cxGridCustomTableView, cxGridTableView, cxGridDBTableView, cxGrid, StrUtils,
   cxContainer, cxTextEdit, cxMaskEdit, cxDropDownEdit, cxLookAndFeels,
   cxLookAndFeelPainters, cxNavigator;

type
   TfrmReceiveSupplierStock = class(TForm)
      Panel1: TPanel;
      Panel2: TPanel;
      Panel3: TPanel;
      Panel4: TPanel;
      memPOheader: TdxMemData;
      btnRefresh: TSpeedButton;
      GrdPOHeaderDBTableView1: TcxGridDBTableView;
      GrdPOHeaderLevel1: TcxGridLevel;
      GrdPOHeader: TcxGrid;
      DataSource1: TDataSource;
      GrdPOHeaderDBTableView1RecId: TcxGridDBColumn;
      GrdPOHeaderDBTableView1OrderNum: TcxGridDBColumn;
      GrdPOHeaderDBTableView1Account: TcxGridDBColumn;
      GrdPOHeaderDBTableView1Name: TcxGridDBColumn;
      GrdPOHeaderDBTableView1OrderDate: TcxGridDBColumn;
      Splitter1: TSplitter;
      GrdPODetail: TcxGrid;
      cxGridDBTableView1: TcxGridDBTableView;
      cxGridLevel1: TcxGridLevel;
      memPODetail: TdxMemData;
      DataSource2: TDataSource;
      cxGridDBTableView1Code: TcxGridDBColumn;
      cxGridDBTableView1Description_1: TcxGridDBColumn;
      cxGridDBTableView1fQuantity: TcxGridDBColumn;
      cxGridDBTableView1fUnitPriceExcl: TcxGridDBColumn;
      btnClose: TSpeedButton;
      cxGridDBTableViewidInvoiceLines: TcxGridDBColumn;
      btnGRV: TButton;
      cxGridDBTableView1ReceivedQty: TcxGridDBColumn;
      cxGridDBTableView1Description_2: TcxGridDBColumn;
      cxGridDBTableView1fQtyProcessed: TcxGridDBColumn;
      GrdPOHeaderDBTableView1AutoIndex: TcxGridDBColumn;
      Label2: TLabel;
      cmbLocations: TcxComboBox;
      cxGridDBTableView1Finalized: TcxGridDBColumn;
      GrdPOHeaderDBTableView1ulIDPOrdConfirmed: TcxGridDBColumn;
      cxGridDBTableView1ItemGroup: TcxGridDBColumn;
      procedure btnCloseClick(Sender: TObject);
      procedure btnRefreshClick(Sender: TObject);
      procedure GrdPOHeaderDBTableView1FocusedRecordChanged(Sender: TcxCustomGridTableView; APrevFocusedRecord, AFocusedRecord: TcxCustomGridRecord;
        ANewItemRecordFocusingChanged: Boolean);
      procedure cxGridDBTableView1fUnitPriceExclGetDisplayText(Sender: TcxCustomGridTableItem; ARecord: TcxCustomGridRecord; var AText: string);
      procedure cxGridDBTableView1fQuantityGetDisplayText(Sender: TcxCustomGridTableItem; ARecord: TcxCustomGridRecord; var AText: string);
      procedure FormCreate(Sender: TObject);
      procedure FormResize(Sender: TObject);
      procedure cxGridDBTableView1DblClick(Sender: TObject);
      procedure btnGRVClick(Sender: TObject);
      procedure cxGridDBTableView1ReceivedQtyGetDisplayText(Sender: TcxCustomGridTableItem; ARecord: TcxCustomGridRecord; var AText: string);
      procedure cxGridDBTableView1fQtyProcessedGetDisplayText(Sender: TcxCustomGridTableItem; ARecord: TcxCustomGridRecord; var AText: string);
      procedure cxGridDBTableView1StylesGetContentStyle(Sender: TcxCustomGridTableView; ARecord: TcxCustomGridRecord; AItem: TcxCustomGridTableItem;
        var AStyle: TcxStyle);
   private
      procedure RefreshPODetail;
      procedure CreateNewStockRoll;
      procedure UpdatePO;
      procedure PrintTheGRV;
      procedure SetBinLocation;
      { Private declarations }
   public
      { Public declarations }
   end;

var
   frmReceiveSupplierStock: TfrmReceiveSupplierStock;
   vPONum: string;
   AuditNo: real;
   GRVPrfx, vCode, vGRVNo: string;
   GRVPad, GRVNo, vStkID, vRollCount, vNewInvID: integer;
   vTaxAmount, vDocValue: real;
   vNumLabels: string;

implementation

uses uDM, uGRVStock, uCommon, uRptGRV;

{$R *.dfm}

procedure TfrmReceiveSupplierStock.btnCloseClick(Sender: TObject);
begin
   close;
end;

procedure TfrmReceiveSupplierStock.btnRefreshClick(Sender: TObject);
begin
   screen.Cursor := crSQLWait;
   if memPOheader.RecordCount > 0 then
      memPOheader.close;
   dm.qryEvo.SQL.Clear;
   dm.qryEvo.SQL.Add('SELECT InvNum.OrderNum, Vendor.Account, Vendor.Name, InvNum.OrderDate, InvNum.AutoIndex,');
   dm.qryEvo.SQL.Add('InvNum.ulIDPOrdConfirmed');
   dm.qryEvo.SQL.Add('FROM InvNum INNER JOIN');
   dm.qryEvo.SQL.Add('Vendor ON InvNum.AccountID = Vendor.DCLink');
   dm.qryEvo.SQL.Add('WHERE (InvNum.DocType = 5)');
   dm.qryEvo.SQL.Add('AND DCLink<>1114');
   dm.qryEvo.SQL.Add('AND (InvNum.DocFlag = 1)');
   dm.qryEvo.SQL.Add('AND ((InvNum.DocState = 1) OR (InvNum.DocState = 3))');
   if not((vStaffID = 'vanessa') or (vStaffID = 'nicholas') or (vStaffID = 'charlene') or (vStaffID = 'nolen')) then
      dm.qryEvo.SQL.Add('AND ulIDPOrdConfirmed = ''Confirmed''');
   dm.qryEvo.SQL.Add('ORDER BY InvNum.OrderNum desc');
   dm.qryEvo.Open;
   memPOheader.LoadFromDataSet(dm.qryEvo);
   memPOheader.First;
   dm.qryEvo.close;
   screen.Cursor := crDefault;
end;

procedure TfrmReceiveSupplierStock.GrdPOHeaderDBTableView1FocusedRecordChanged(Sender: TcxCustomGridTableView;
  APrevFocusedRecord, AFocusedRecord: TcxCustomGridRecord; ANewItemRecordFocusingChanged: Boolean);
begin
   RefreshPODetail;
end;

procedure TfrmReceiveSupplierStock.RefreshPODetail;
begin
   memPODetail.close;
   dm.qryEvo.SQL.Clear;
   dm.qryEvo.SQL.Add('SELECT StkItem.Code, StkItem.Description_1, StkItem.ItemGroup, _btblInvoiceLines.fQuantity,  _btblInvoiceLines.fQtyProcessed,');
   dm.qryEvo.SQL.Add('_btblInvoiceLines.fUnitPriceExcl, _btblInvoiceLines.idInvoiceLines, SUM(ISNULL(HertexRollStk.dbo.PurchaseOrder.Qty, 0)) AS QtyReceived,');
   dm.qryEvo.SQL.Add('Max(isnull(finalized,0)) Finalized,');
   dm.qryEvo.SQL.Add('StkItem.Description_2');
   dm.qryEvo.SQL.Add('FROM InvNum INNER JOIN');
   dm.qryEvo.SQL.Add('_btblInvoiceLines ON InvNum.AutoIndex = _btblInvoiceLines.iInvoiceID INNER JOIN');
   dm.qryEvo.SQL.Add('Vendor ON InvNum.AccountID = Vendor.DCLink INNER JOIN');
   dm.qryEvo.SQL.Add('StkItem ON _btblInvoiceLines.iStockCodeID = StkItem.StockLink LEFT OUTER JOIN');
   dm.qryEvo.SQL.Add('HertexRollStk.dbo.PurchaseOrder ON StkItem.Code = HertexRollStk.dbo.PurchaseOrder.StockCode COLLATE SQL_Latin1_General_CP1_CI_AS AND');
   dm.qryEvo.SQL.Add('InvNum.OrderNum = HertexRollStk.dbo.PurchaseOrder.OrderNumber COLLATE SQL_Latin1_General_CP1_CI_AS');
   dm.qryEvo.SQL.Add('WHERE InvNum.OrderNum = ' + quotedstr(memPOheader.fieldbyname('OrderNum').AsString));
   dm.qryEvo.SQL.Add('AND (InvNum.DocType = 5)');
   dm.qryEvo.SQL.Add('AND (InvNum.DocFlag = 1)');
   dm.qryEvo.SQL.Add('AND ((InvNum.DocState = 1) OR (InvNum.DocState = 3))');
   // dm.qryEvo.SQL.Add('AND (_btblInvoiceLines.fQuantity - _btblInvoiceLines.fQtyProcessed > 0)');
   dm.qryEvo.SQL.Add('GROUP BY StkItem.Code, StkItem.Description_1, StkItem.ItemGroup, _btblInvoiceLines.fQuantity, _btblInvoiceLines.fQtyProcessed,');
   dm.qryEvo.SQL.Add('_btblInvoiceLines.fUnitPriceExcl, _btblInvoiceLines.idInvoiceLines, StkItem.Description_2');
   // dm.qryEvo.SQL.Add('_btblInvoiceLines.fUnitPriceExcl, _btblInvoiceLines.idInvoiceLines, HertexRollStk.dbo.PurchaseOrder.DyeLot, StkItem.Description_2');
   dm.qryEvo.SQL.Add('ORDER BY idInvoiceLines');
   dm.qryEvo.Open;
   memPODetail.LoadFromDataSet(dm.qryEvo);
   btnGRV.Enabled := memPOheader.fieldbyname('ulIDPOrdConfirmed').AsString = 'Confirmed';
   memPODetail.First;
   SetBinLocation;
   dm.qryEvo.close;
end;

procedure TfrmReceiveSupplierStock.cxGridDBTableView1fUnitPriceExclGetDisplayText(Sender: TcxCustomGridTableItem; ARecord: TcxCustomGridRecord;
  var AText: string);
begin
   AText := formatfloat('R,0.00', StrToFloat(AText));
end;

procedure TfrmReceiveSupplierStock.cxGridDBTableView1fQuantityGetDisplayText(Sender: TcxCustomGridTableItem; ARecord: TcxCustomGridRecord; var AText: string);
begin
   AText := formatfloat(',0.00', StrToFloat(AText));
end;

procedure TfrmReceiveSupplierStock.FormCreate(Sender: TObject);
begin
   dm.qryStk.close;
   cmbLocations.Properties.Items.Clear;
   cmbLocations.Properties.Items.Add('BBSDOC'); // all fabric and samples to be booked into this bin by default
   cmbLocations.Properties.Items.Add('TRSDOC'); // all HAUS to be booked into this bin by default
   cmbLocations.Properties.Items.Add('CRSDOC');
   cmbLocations.Properties.Items.Add('RSSDOC');
   cmbLocations.Properties.Items.Add('WHSDOC');
   cmbLocations.Properties.Items.Add('DOC');
   cmbLocations.Properties.Items.Add('SS001');
   cmbLocations.Properties.Items.Add('MF001');
   btnRefreshClick(nil);
end;

procedure TfrmReceiveSupplierStock.FormResize(Sender: TObject);
begin
   btnClose.Left := Panel3.Width - btnClose.Width;
end;

procedure TfrmReceiveSupplierStock.cxGridDBTableView1DblClick(Sender: TObject);
begin
   if memPODetail.RecordCount <= 0 then
      exit;
   if (memPODetail.fieldbyname('fQuantity').AsCurrency - memPODetail.fieldbyname('fQtyProcessed').AsCurrency) <= 0 then
   begin
      messagedlg('This item has already been processed in full.', mtInformation, [mbOK], 0);
      exit;
   end;
   if (memPODetail.fieldbyname('ItemGroup').AsString = '001') or (memPODetail.fieldbyname('ItemGroup').AsString = '002') or
     (memPODetail.fieldbyname('ItemGroup').AsString = '003') or (memPODetail.fieldbyname('ItemGroup').AsString = '004') or
     (memPODetail.fieldbyname('ItemGroup').AsString = '005') or (memPODetail.fieldbyname('ItemGroup').AsString = '006') or
     (memPODetail.fieldbyname('ItemGroup').AsString = '006') or (memPODetail.fieldbyname('ItemGroup').AsString = '009') or
     (memPODetail.fieldbyname('ItemGroup').AsString = '011') or (memPODetail.fieldbyname('ItemGroup').AsString = '012') then
   begin //
      frmGRVStock := TfrmGRVStock.Create(nil);
      frmGRVStock.ItemGroup.Text := memPODetail.fieldbyname('ItemGroup').AsString;
      frmGRVStock.edtDyeLot.Text := '';
      frmGRVStock.edtSupplDyeLot.Text := '';
      frmGRVStock.Description_2.Text := memPODetail.fieldbyname('Description_2').AsString;
      frmGRVStock.QtyOrdered.Value := memPODetail.fieldbyname('fQuantity').AsCurrency - memPODetail.fieldbyname('fQtyProcessed').AsCurrency;
      frmGRVStock.vOrigQty := memPODetail.fieldbyname('fQuantity').AsCurrency - memPODetail.fieldbyname('fQtyProcessed').AsCurrency;
      frmGRVStock.RollQuantity.Value := 0;
      frmGRVStock.QtyRemaining.Value := memPODetail.fieldbyname('fQuantity').AsCurrency - memPODetail.fieldbyname('fQtyProcessed').AsCurrency;
      frmGRVStock.ProductCode.Text := memPODetail.fieldbyname('Code').AsString;
      frmGRVStock.Description.Text := memPODetail.fieldbyname('Description_1').AsString;
      frmGRVStock.PONumber.Text := memPOheader.fieldbyname('OrderNum').AsString;
      frmGRVStock.UnitPrice.Value := memPODetail.fieldbyname('fUnitPriceExcl').AsCurrency;
      frmGRVStock.DateReceived.Date := Date;
      frmGRVStock.vLineID := memPODetail.fieldbyname('idInvoiceLines').AsInteger;
      frmGRVStock.chbOrderComplete.Checked := memPODetail.fieldbyname('Finalized').AsInteger = 1;
      frmGRVStock.vAllowance := (memPODetail.fieldbyname('fQuantity').AsCurrency * 0.2);
      frmGRVStock.LoadGRVData;
      frmGRVStock.ShowModal;
      if frmGRVStock.chbOrderComplete.Checked then
      begin
         dm.qryEvo.SQL.Clear;
         if frmGRVStock.vOrigQty < frmGRVStock.QtyOrdered.Value then
            dm.qryEvo.SQL.Add('update _btblinvoicelines set fquantity = fquantity + ' + FloatToStr(frmGRVStock.QtyOrdered.Value - frmGRVStock.vOrigQty))
         else
            dm.qryEvo.SQL.Add('update _btblinvoicelines set fquantity = fquantity - ' + FloatToStr(frmGRVStock.QtyRemaining.Value));
         dm.qryEvo.SQL.Add('where idInvoiceLines = ' + IntToStr(memPODetail.fieldbyname('idInvoiceLines').AsInteger));
         dm.qryEvo.ExecSQL;
      end
   end
   else
   begin // Retail
      frmGRVStock := TfrmGRVStock.Create(nil);
      frmGRVStock.ItemGroup.Text := memPODetail.fieldbyname('ItemGroup').AsString;
      frmGRVStock.edtDyeLot.Text := '';
      frmGRVStock.edtSupplDyeLot.Text := '';
      frmGRVStock.Description_2.Text := memPODetail.fieldbyname('Description_2').AsString;
      frmGRVStock.QtyOrdered.Value := memPODetail.fieldbyname('fQuantity').AsCurrency - memPODetail.fieldbyname('fQtyProcessed').AsCurrency;
      frmGRVStock.vOrigQty := memPODetail.fieldbyname('fQuantity').AsCurrency - memPODetail.fieldbyname('fQtyProcessed').AsCurrency;
      frmGRVStock.RollQuantity.Value := 0;
      frmGRVStock.QtyRemaining.Value := memPODetail.fieldbyname('fQuantity').AsCurrency - memPODetail.fieldbyname('fQtyProcessed').AsCurrency;
      frmGRVStock.ProductCode.Text := memPODetail.fieldbyname('Code').AsString;
      frmGRVStock.Description.Text := memPODetail.fieldbyname('Description_1').AsString;
      frmGRVStock.PONumber.Text := memPOheader.fieldbyname('OrderNum').AsString;
      frmGRVStock.UnitPrice.Value := memPODetail.fieldbyname('fUnitPriceExcl').AsCurrency;
      frmGRVStock.DateReceived.Date := Date;
      frmGRVStock.vLineID := memPODetail.fieldbyname('idInvoiceLines').AsInteger;
      frmGRVStock.chbOrderComplete.Checked := memPODetail.fieldbyname('Finalized').AsInteger = 1;
      frmGRVStock.vAllowance := (memPODetail.fieldbyname('fQuantity').AsCurrency * 0.2);
      frmGRVStock.LoadGRVData;
      frmGRVStock.Label2.Caption := 'Number of items';
      frmGRVStock.ShowModal;
      if frmGRVStock.chbOrderComplete.Checked then
      begin
         dm.qryEvo.SQL.Clear;
         if frmGRVStock.vOrigQty < frmGRVStock.QtyOrdered.Value then
            dm.qryEvo.SQL.Add('update _btblinvoicelines set fquantity = fquantity + ' + FloatToStr(frmGRVStock.QtyOrdered.Value - frmGRVStock.vOrigQty))
         else
            dm.qryEvo.SQL.Add('update _btblinvoicelines set fquantity = fquantity - ' + FloatToStr(frmGRVStock.QtyRemaining.Value));
         dm.qryEvo.SQL.Add('where idInvoiceLines = ' + IntToStr(memPODetail.fieldbyname('idInvoiceLines').AsInteger));
         dm.qryEvo.ExecSQL;
      end;
   end;
   frmGRVStock.Release;
   RefreshPODetail;
   SetBinLocation;
   memPODetail.First;
end;

procedure TfrmReceiveSupplierStock.SetBinLocation;
begin
   memPODetail.First;
   cmbLocations.Text := 'TRSDOC';
   while not memPODetail.Eof do
   begin
      if ((memPODetail.fieldbyname('ItemGroup').AsString = '002') or (memPODetail.fieldbyname('ItemGroup').AsString = '003') or
        (memPODetail.fieldbyname('ItemGroup').AsString = '005')) and (memPODetail.fieldbyname('QtyReceived').AsCurrency <> 0) then
      begin
         cmbLocations.Text := 'BBSDOC';
         break;
      end;
      memPODetail.Next;
   end;
   memPODetail.First;
end;

procedure TfrmReceiveSupplierStock.btnGRVClick(Sender: TObject);
var
   x: integer;
begin
   if cmbLocations.Text = '' then
   begin
      messagedlg('Please select a bin location for all these items', mtError, [mbOK], 0);
      cmbLocations.SetFocus;
      exit;
   end;
   if lowercase(cmbLocations.Text) = 'photo' then
   begin
      if not((vStaffID = 'vanessa') or (vStaffID = 'cheslyn') or (vStaffID = 'richard')) then
      begin
         messagedlg('You are not permitted to use this bin location', mtError, [mbOK], 0);
         exit;
      end;
   end;
   vPONum := memPOheader.fieldbyname('OrderNum').AsString;
   vRollCount := 0;
   if messagedlg('Are you sure that you want to create a GRV for Purchase Order number ' + vPONum + '?', mtCOnfirmation, [mbYes, mbNO], 0) = mrNo then
      exit;
   screen.Cursor := crSQLWait;
   try
      if (vStaffID = 'nicholas') then
      begin
      end
      else
         UpdatePO;
      CreateNewStockRoll;
      dm.qryStk.SQL.Clear;
      dm.qryStk.SQL.Add('select RollID from PurchaseOrder');
      dm.qryStk.SQL.Add('where OrderNumber = ' + quotedstr(vPONum));
      dm.qryStk.SQL.Add('and PrintedBarcode = 0');
      dm.qryStk.SQL.Add('and ROllID <> 0');
      dm.qryStk.Open;
      while not dm.qryStk.Eof do
      begin
         for x := 1 to StrToInt(vNumLabels) do
         begin
            application.ProcessMessages;
            PrintTheBarcode(IntToStr(dm.qryStk.fieldbyname('RollID').AsInteger), false);
            sleep(100);
         end;
         dm.qryStk.Next;
      end;
      dm.qryStk.close;

      dm.qryStk.SQL.Clear;
      dm.qryStk.SQL.Add('delete from PurchaseOrder');
      dm.qryStk.SQL.Add('where OrderNumber = ' + quotedstr(vPONum));
      dm.qryStk.ExecSQL;
      PrintTheGRV;
      messagedlg('Sucessfully created the GRV and put ' + IntToStr(vRollCount) + ' units into stock.', mtInformation, [mbOK], 0);
      btnRefreshClick(nil);
   except
      on e: exception do
      begin
         screen.Cursor := crDefault;
         messagedlg('Could not create this GRV due to a system error:' + #13 + e.message, mtError, [mbOK], 0);
      end;
   end;
   memPODetail.First;
   screen.Cursor := crDefault;
end;

procedure TfrmReceiveSupplierStock.UpdatePO;
var
   vRemain: real;
begin
   dm.qryEvo.SQL.Clear;
   dm.qryEvo.SQL.Add('SELECT TOP 1 * FROM StDfTbl');
   dm.qryEvo.Open;
   GRVPrfx := dm.qryEvo.fieldbyname('GRVPref').AsString;
   GRVPad := dm.qryEvo.fieldbyname('GRVPad').AsInteger;
   GRVNo := dm.qryEvo.fieldbyname('GRVNum').AsInteger;
   vGRVNo := GRVPrfx + rightstr('000000' + IntToStr(GRVNo), GRVPad);
   AuditNo := GetNextAuditNo;
   dm.qryEvo.SQL.Clear;
   dm.qryEvo.SQL.Add('update StDfTbl set GRVNum = GRVNum + 1');
   dm.qryEvo.ExecSQL;
   dm.qryEvo.close;
   memPODetail.First;
   vDocValue := 0;
   vRemain := 0;
   while not memPODetail.Eof do
   begin
      vRemain := vRemain + memPODetail.fieldbyname('fQuantity').AsCurrency - memPODetail.fieldbyname('fQtyProcessed').AsCurrency -
        memPODetail.fieldbyname('QtyReceived').AsCurrency;
      memPODetail.Next;
   end;
   dm.usr_UpdatePO_Step1.Parameters[1].Value := memPOheader.fieldbyname('AutoIndex').AsInteger;
   dm.usr_UpdatePO_Step1.Parameters[2].Value := vGRVNo;
   if vRemain = 0 then
      dm.usr_UpdatePO_Step1.Parameters[3].Value := 'F'
   else
      dm.usr_UpdatePO_Step1.Parameters[3].Value := 'G';
   dm.usr_UpdatePO_Step1.ExecProc;
   if vRemain = 0 then
      vNewInvID := memPOheader.fieldbyname('AutoIndex').AsInteger
   else
      vNewInvID := dm.usr_UpdatePO_Step1.Parameters[0].Value;
   memPODetail.First;
   while not memPODetail.Eof do
   begin
      dm.usr_UpdatePO_Step2.Parameters[1].Value := vGRVNo;
      dm.usr_UpdatePO_Step2.Parameters[2].Value := vPONum;
      dm.usr_UpdatePO_Step2.Parameters[3].Value := Date;
      dm.usr_UpdatePO_Step2.Parameters[4].Value := memPODetail.fieldbyname('QtyReceived').AsCurrency;
      dm.usr_UpdatePO_Step2.Parameters[5].Value := memPODetail.fieldbyname('idInvoiceLines').AsInteger;
      dm.usr_UpdatePO_Step2.Parameters[6].Value := memPODetail.fieldbyname('Code').AsString;
      dm.usr_UpdatePO_Step2.Parameters[7].Value := memPODetail.fieldbyname('fUnitPriceExcl').AsCurrency;
      dm.usr_UpdatePO_Step2.Parameters[9].Value := AuditNo;
      dm.usr_UpdatePO_Step2.Parameters[10].Value := vNewInvID;
      if vRemain = 0 then
         dm.usr_UpdatePO_Step2.Parameters[11].Value := 'F' // Create the finalised GRV
      else
         dm.usr_UpdatePO_Step2.Parameters[11].Value := 'G'; // Create the GRV
      dm.usr_UpdatePO_Step2.ExecProc;
      memPODetail.Next;
   end;
   // Update the header totals
   dm.usr_UpdatePO_Step3.Parameters[1].Value := memPOheader.fieldbyname('AutoIndex').AsInteger; // Original Header
   dm.usr_UpdatePO_Step3.Parameters[2].Value := AuditNo;
   dm.usr_UpdatePO_Step3.ExecProc;
   dm.usr_UpdatePO_Step3.Parameters[1].Value := vNewInvID; // Copy
   if vRemain = 0 then
      dm.usr_UpdatePO_Step3.Parameters[2].Value := -1
   else
      dm.usr_UpdatePO_Step3.Parameters[2].Value := 0;
   dm.usr_UpdatePO_Step3.ExecProc;
   memPODetail.First;
   dm.usr_UpdatePO_Step1.Parameters[1].Value := memPOheader.fieldbyname('AutoIndex').AsInteger;
   dm.usr_UpdatePO_Step1.Parameters[2].Value := vGRVNo;
   dm.usr_UpdatePO_Step1.Parameters[3].Value := 'I'; // Create the unprocessed supplier Invoice
   dm.usr_UpdatePO_Step1.ExecProc;
   vNewInvID := dm.usr_UpdatePO_Step1.Parameters[0].Value;
   while not memPODetail.Eof do
   begin
      dm.usr_UpdatePO_Step2.Parameters[1].Value := vGRVNo;
      dm.usr_UpdatePO_Step2.Parameters[2].Value := vPONum;
      dm.usr_UpdatePO_Step2.Parameters[3].Value := Date;
      dm.usr_UpdatePO_Step2.Parameters[4].Value := memPODetail.fieldbyname('QtyReceived').AsCurrency;
      dm.usr_UpdatePO_Step2.Parameters[5].Value := memPODetail.fieldbyname('idInvoiceLines').AsInteger;
      dm.usr_UpdatePO_Step2.Parameters[6].Value := memPODetail.fieldbyname('Code').AsString;
      dm.usr_UpdatePO_Step2.Parameters[7].Value := memPODetail.fieldbyname('fUnitPriceExcl').AsCurrency;
      dm.usr_UpdatePO_Step2.Parameters[9].Value := AuditNo;
      dm.usr_UpdatePO_Step2.Parameters[10].Value := vNewInvID;
      dm.usr_UpdatePO_Step2.Parameters[11].Value := 'I'; // Create the unprocessed Invoice lines
      dm.usr_UpdatePO_Step2.ExecProc;
      memPODetail.Next;
   end;
end;

procedure TfrmReceiveSupplierStock.CreateNewStockRoll;
var
   vSupID, vRollID: integer;
   vBarcode: string;
begin
   memPODetail.First;
   dm.qryEvo.SQL.Clear;
   dm.qryEvo.SQL.Add('select top 1 AccountID from invnum where OrderNum = ' + quotedstr(vPONum));
   dm.qryEvo.Open;
   vSupID := dm.qryEvo.Fields[0].AsInteger;
   dm.qryEvo.close;
   dm.qryStk.SQL.Clear;
   dm.qryStk.SQL.Add('select PurchaseOrderID, StockCode, Qty Length, UnitPriceExcl, Available, DyeLot, SupplierDyeLot, ItemGroup from PurchaseOrder');
   dm.qryStk.SQL.Add('where OrderNumber = ' + quotedstr(vPONum));
   dm.qryStk.Open;
   vRollCount := vRollCount + dm.qryStk.RecordCount;
   if not dm.qryStk.Eof then
      while true do
      begin
         vNumLabels := inputbox('Print Stock Labels', 'Number of labels needed', '2');
         try
            StrToInt(vNumLabels);
            break;
         except
         end;
      end;
   while not dm.qryStk.Eof do
   begin
      dm.usr_AddRoll.Parameters[1].Value := AuditNo;
      dm.usr_AddRoll.Parameters[2].Value := dm.qryStk.fieldbyname('StockCode').AsString;
      dm.usr_AddRoll.Parameters[3].Value := vSupID;
      dm.usr_AddRoll.Parameters[4].Value := vPONum;
      dm.usr_AddRoll.Parameters[5].Value := vGRVNo;
      dm.usr_AddRoll.Parameters[6].Value := dm.qryStk.fieldbyname('UnitPriceExcl').AsCurrency;
      dm.usr_AddRoll.Parameters[7].Value := dm.qryStk.fieldbyname('Length').AsCurrency;
      dm.usr_AddRoll.Parameters[8].Value := cmbLocations.Text;
      dm.usr_AddRoll.Parameters[9].Value := 'Y';
      dm.usr_AddRoll.ExecProc;
      vRollID := dm.usr_AddRoll.Parameters[0].Value;
      vBarcode := formatdatetime('yymm', Date) + formatfloat('000000', vRollID) + formatfloat('000000', dm.qryStk.fieldbyname('Length').AsCurrency * 100);
      dm.qryStk1.SQL.Clear;
      dm.qryStk1.SQL.Add('update PurchaseOrder set RollID = ' + IntToStr(vRollID) + ' where PurchaseOrderID = ' +
        IntToStr(dm.qryStk.fieldbyname('PurchaseOrderID').AsInteger));
      dm.qryStk1.ExecSQL;
      dm.qryStk1.SQL.Clear;
      dm.qryStk1.SQL.Add('update StockRollHdr set Barcode = ' + quotedstr(vBarcode));
      dm.qryStk1.SQL.Add(',DateUpdated = getdate()');
      dm.qryStk1.SQL.Add(',GRVDate = getdate()');
      dm.qryStk1.SQL.Add(',DyeLot = ' + quotedstr(formatdatetime('dd/mm/yy', Date) + ' ' + dm.qryStk.fieldbyname('DyeLot').AsString));
      dm.qryStk1.SQL.Add(',SupplierDyeLot = ' + quotedstr(dm.qryStk.fieldbyname('SupplierDyeLot').AsString));
      dm.qryStk1.SQL.Add(',GRVStockCode = ' + quotedstr(dm.qryStk.fieldbyname('StockCode').AsString));
      dm.qryStk1.SQL.Add('where StockRollId = ' + IntToStr(vRollID));
      dm.qryStk1.ExecSQL;
      dm.qryStk.Next;
   end;
end;

procedure TfrmReceiveSupplierStock.cxGridDBTableView1ReceivedQtyGetDisplayText(Sender: TcxCustomGridTableItem; ARecord: TcxCustomGridRecord; var AText: string);
begin
   AText := formatfloat(',0.00', StrToFloat(AText));
end;

procedure TfrmReceiveSupplierStock.cxGridDBTableView1StylesGetContentStyle(Sender: TcxCustomGridTableView; ARecord: TcxCustomGridRecord;
  AItem: TcxCustomGridTableItem; var AStyle: TcxStyle);
begin
   if ARecord is TcxGridDataRow then
   begin
      if ARecord.Values[cxGridDBTableView1fQtyProcessed.Index] >= ARecord.Values[cxGridDBTableView1fQuantity.Index] then
         AStyle := dm.POdone;
   end;
end;

procedure TfrmReceiveSupplierStock.cxGridDBTableView1fQtyProcessedGetDisplayText(Sender: TcxCustomGridTableItem; ARecord: TcxCustomGridRecord;
  var AText: string);
begin
   AText := formatfloat(',0.00', StrToFloat(AText));
end;

procedure TfrmReceiveSupplierStock.PrintTheGRV;
begin
   application.ProcessMessages;
   frmRptGRV := TfrmRptGRV.Create(nil);
   frmRptGRV.ADOQuery1.Parameters[0].Value := vGRVNo;
   frmRptGRV.ADOQuery1.Open;
   if frmRptGRV.ADOQuery1.RecordCount > 0 then
   begin
      if vStaffID = 'nicholas' then
         frmRptGRV.QuickRep1.PreviewModal
      else
      begin
         frmRptGRV.QuickRep1.Print;
         frmRptGRV.QuickRep1.Print;
      end;
      frmRptGRV.ADOQuery1.close;
      frmRptGRV.Destroy;
   end;
end;

end.
