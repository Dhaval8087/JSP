using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using System;
using System.Data;

namespace JSP.ViewModels
{

    public class CreatePdf
    {

        BaseFont f_cb = BaseFont.CreateFont("c:\\windows\\fonts\\calibrib.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        BaseFont f_cn = BaseFont.CreateFont("c:\\windows\\fonts\\calibri.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);


        public static string Directory;
        public string CreatePdf12(InvoiceInformationViewModel viewmodel)
        {
            Microsoft.Win32.SaveFileDialog _SD = new Microsoft.Win32.SaveFileDialog();
            try
            {
                MemoryStream myMemoryStream = new MemoryStream();
                Document myDocument = new Document();
                myDocument.SetPageSize(PageSize.A4);
                PdfWriter myPDFWriter = PdfWriter.GetInstance(myDocument, myMemoryStream);
                PageEventHelper pageEventHelper = new PageEventHelper();
                myPDFWriter.PageEvent = pageEventHelper;

                myDocument.Open();
                PdfContentByte cb = myPDFWriter.DirectContent;
                MultiColumnText columns = new MultiColumnText();
                columns.AddSimpleColumn(46f, 500);
                ColumnText TO = new ColumnText(cb);
                TO.SetSimpleColumn(new Phrase(new Chunk("Subject to Vadodara Jurisdiction Only", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD))),
                                    230, 100, 530, 100, -730, Element.ALIGN_CENTER | Element.ALIGN_TOP);
                TO.Go();


                BaseFont bf_qty123 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                Font BlackFont = new Font(Font.FontFamily.TIMES_ROMAN, 10, Font.BOLD, BaseColor.BLACK);

                ColumnText ContactP = new ColumnText(cb);
                ContactP.SetSimpleColumn(new Phrase(new Chunk(viewmodel.CompanyDetails.Name, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 13, Font.UNDERLINE | Font.BOLDITALIC))),
                                    390, 100, 530, 100, -695, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                ContactP.Go();


                ColumnText ContactNumber = new ColumnText(cb);
                ContactNumber.SetSimpleColumn(new Phrase(new Chunk(viewmodel.CompanyDetails.Address1, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL))),
                                    390, 100, 570, 100, -680, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                ContactNumber.Go();

                ColumnText ContactAddress = new ColumnText(cb);
                ContactAddress.SetSimpleColumn(new Phrase(new Chunk(viewmodel.CompanyDetails.Address2 + " " + viewmodel.CompanyDetails.City + " " + viewmodel.CompanyDetails.PinCode, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL))),
                                    390, 100, 570, 100, -670, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                ContactAddress.Go();


                ColumnText ContactEmail = new ColumnText(cb);
                ContactEmail.SetSimpleColumn(new Phrase(new Chunk("Email :- " + viewmodel.CompanyDetails.Email, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL))),
                                    390, 100, 530, 100, -660, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                ContactEmail.Go();

                ColumnText ContactPhone = new ColumnText(cb);
                ContactPhone.SetSimpleColumn(new Phrase(new Chunk("Mo.No - " + viewmodel.CompanyDetails.Mobile, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL))),
                                    390, 100, 530, 100, -650, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                ContactPhone.Go();






                DateTime dt = Convert.ToDateTime(DateTime.Now);
                string currenetdate = dt.ToString("d-MMM-yy");
                int index = currenetdate.IndexOf("-");
                if (index != 2)
                {

                    for (int j = 1; j < 10; j++)
                    {

                        if (int.Parse(currenetdate.Substring(0, 1)) == j)
                        {
                            currenetdate = "0" + currenetdate;
                            break;
                        }
                    }
                }


                Phrase newline0 = new Phrase(Environment.NewLine);

                for (int newline = 0; newline < 6; newline++)
                {
                    myDocument.Add(newline0);
                }
                //Hansgrohe Product Specification

                ColumnText TableHeader = new ColumnText(cb);
                TableHeader.SetSimpleColumn(new Phrase(new Chunk("INVOICE", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 20, Font.BOLD | Font.UNDERLINE))),
                                     230, 100, 530, 100, -600, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                TableHeader.Go();

                ColumnText billto = new ColumnText(cb);
                billto.SetSimpleColumn(new Phrase(new Chunk("BILL TO:-", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD))),
                                     45, 100, 530, 100, -560, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                billto.Go();

                ColumnText clientadd = new ColumnText(cb);
                clientadd.SetSimpleColumn(new Phrase(new Chunk(viewmodel.Client.Name, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL))),
                                     100, 100, 570, 100, -550, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                clientadd.Go();

                ColumnText clientadd1 = new ColumnText(cb);
                clientadd1.SetSimpleColumn(new Phrase(new Chunk(viewmodel.Client.Address1 + " " + viewmodel.Client.Address2, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL))),
                                     100, 100, 570, 100, -540, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                clientadd1.Go();

                ColumnText clientadd2 = new ColumnText(cb);
                clientadd2.SetSimpleColumn(new Phrase(new Chunk(viewmodel.Client.City + " " + viewmodel.Client.PinCode, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL))),
                                     100, 100, 570, 100, -530, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                clientadd2.Go();

                ColumnText S_Date_Date = new ColumnText(cb);
                S_Date_Date.SetSimpleColumn(new Phrase(new Chunk("DATE", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD))),
                                    390, 100, 530, 100, -560, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                S_Date_Date.Go();

                string invoideDate = viewmodel.InvoiceDate.ToString("dd-MMM-yyyy");
                BaseFont bfcurrent = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                Font fontcurrent = new Font(bfcurrent, 10, Font.NORMAL, BaseColor.BLACK);
                Chunk chcurrent = new Chunk(invoideDate, fontcurrent);
                ColumnText S_Date = new ColumnText(cb);
                S_Date.SetSimpleColumn(new Phrase(chcurrent),
                                                    390, 100, 530, 100, -550, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                S_Date.Go();

                ColumnText Invoice_Date = new ColumnText(cb);
                Invoice_Date.SetSimpleColumn(new Phrase(new Chunk("INVOICE", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD))),
                                    390, 100, 530, 100, -530, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                Invoice_Date.Go();

                ColumnText S_Inv_Date = new ColumnText(cb);
                Chunk invoicechunk = new Chunk("2018/04/001", fontcurrent);
                S_Inv_Date.SetSimpleColumn(new Phrase(invoicechunk),
                                                    390, 100, 530, 100, -520, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                S_Inv_Date.Go();

                ColumnText description = new ColumnText(cb);
                description.SetSimpleColumn(new Phrase(new Chunk("DESCRIPTION", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD))),
                                     130, 100, 530, 100, -490, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                description.Go();
                ColumnText rate = new ColumnText(cb);
                rate.SetSimpleColumn(new Phrase(new Chunk("RATE", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD))),
                                     390, 100, 530, 100, -490, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                rate.Go();

                ColumnText amount = new ColumnText(cb);
                amount.SetSimpleColumn(new Phrase(new Chunk("AMOUNT", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD))),
                                     450, 100, 530, 100, -490, Element.ALIGN_RIGHT | Element.ALIGN_TOP);
                amount.Go();

                //string text = @"The result can be seen below, which shows the text having been written";


                ColumnText descriptiondata = new ColumnText(cb);
                descriptiondata.SetSimpleColumn(new Phrase(new Chunk(viewmodel.Description, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL))),
                                     45, 100, 530, 100, -470, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                descriptiondata.Go();

                ColumnText AY = new ColumnText(cb);
                AY.SetSimpleColumn(new Phrase(new Chunk(viewmodel.Description1, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL))),
                                     45, 100, 530, 100, -460, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                AY.Go();

                ColumnText AY1 = new ColumnText(cb);
                AY1.SetSimpleColumn(new Phrase(new Chunk(viewmodel.Description2, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL))),
                                     45, 100, 530, 100, -450, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                AY1.Go();

                /*ColumnText prevyear = new ColumnText(cb);
                prevyear.SetSimpleColumn(new Phrase(new Chunk("AY 2016-17", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL))),
                                     45, 100, 530, 100, -410, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                prevyear.Go();*/
                ColumnText currentyear = new ColumnText(cb);
                currentyear.SetSimpleColumn(new Phrase(new Chunk("AY 2017-18", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL))),
                                     45, 100, 530, 100, -360, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                currentyear.Go();

                /*ColumnText prevRate = new ColumnText(cb);
                prevRate.SetSimpleColumn(new Phrase(new Chunk("2000", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL))),
                                     390, 100, 530, 100, -410, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                prevRate.Go();*/
                /*ColumnText prevAmount = new ColumnText(cb);
                prevAmount.SetSimpleColumn(new Phrase(new Chunk("2000", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL))),
                                     450, 100, 530, 100, -410, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                prevAmount.Go();*/


                ColumnText currRate = new ColumnText(cb);
                currRate.SetSimpleColumn(new Phrase(new Chunk(viewmodel.Rate.ToString(), FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL))),
                                     390, 100, 530, 100, -360, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                currRate.Go();
                ColumnText currAmount = new ColumnText(cb);
                currAmount.SetSimpleColumn(new Phrase(new Chunk(viewmodel.Rate.ToString(), FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL))),
                                     450, 100, 530, 100, -360, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                currAmount.Go();

                ColumnText companyPan = new ColumnText(cb);
                companyPan.SetSimpleColumn(new Phrase(new Chunk("Company's PAN : ", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD))),
                                     45, 100, 530, 100, -100, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                companyPan.Go();

                ColumnText companyPanVal = new ColumnText(cb);
                companyPanVal.SetSimpleColumn(new Phrase(new Chunk(viewmodel.CompanyDetails.PAN, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL))),
                                     125, 100, 530, 100, -100, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                companyPanVal.Go();

                ColumnText subTotal = new ColumnText(cb);
                subTotal.SetSimpleColumn(new Phrase(new Chunk("SUB TOTAL", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD))),
                                     380, 100, 530, 100, -100, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                subTotal.Go();

                ColumnText subTotalVal = new ColumnText(cb);
                subTotalVal.SetSimpleColumn(new Phrase(new Chunk(viewmodel.Rate.ToString(), FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL))),
                                     450, 100, 530, 100, -100, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                subTotalVal.Go();

                ColumnText sgst = new ColumnText(cb);
                sgst.SetSimpleColumn(new Phrase(new Chunk("SGST", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD))),
                                     380, 100, 530, 100, -85, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                sgst.Go();

                ColumnText sgstVal = new ColumnText(cb);
                sgstVal.SetSimpleColumn(new Phrase(new Chunk("0", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL))),
                                     450, 100, 530, 100, -85, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                sgstVal.Go();


                ColumnText cgst = new ColumnText(cb);
                cgst.SetSimpleColumn(new Phrase(new Chunk("CGST", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD))),
                                     380, 100, 530, 100, -70, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                cgst.Go();

                ColumnText cgstVal = new ColumnText(cb);
                cgstVal.SetSimpleColumn(new Phrase(new Chunk("0", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL))),
                                     450, 100, 530, 100, -70, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                cgstVal.Go();


                ColumnText total = new ColumnText(cb);
                total.SetSimpleColumn(new Phrase(new Chunk("TOTAL", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD))),
                                     380, 100, 530, 100, -55, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                total.Go();

                ColumnText totalVal = new ColumnText(cb);
                totalVal.SetSimpleColumn(new Phrase(new Chunk(viewmodel.Rate.ToString(), FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL))),
                                     450, 100, 530, 100, -55, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                totalVal.Go();


                ColumnText bankdetais = new ColumnText(cb);
                bankdetais.SetSimpleColumn(new Phrase(new Chunk("Company's Bank Details", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD))),
                                     45, 100, 530, 100, -55, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                bankdetais.Go();

                ColumnText bankname = new ColumnText(cb);
                bankname.SetSimpleColumn(new Phrase(new Chunk("Bank Name", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD))),
                                     45, 100, 530, 100, -30, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                bankname.Go();

                ColumnText banknameVal = new ColumnText(cb);
                banknameVal.SetSimpleColumn(new Phrase(new Chunk(viewmodel.CompanyDetails.BankName, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL))),
                                     180, 100, 530, 100, -30, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                banknameVal.Go();

                ColumnText accountno = new ColumnText(cb);
                accountno.SetSimpleColumn(new Phrase(new Chunk("A/c no", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD))),
                                     45, 100, 530, 100, -20, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                accountno.Go();

                ColumnText accountnoVal = new ColumnText(cb);
                accountnoVal.SetSimpleColumn(new Phrase(new Chunk(viewmodel.CompanyDetails.AccountNumber, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL))),
                                     180, 100, 530, 100, -20, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                accountnoVal.Go();

                ColumnText ifsc = new ColumnText(cb);
                ifsc.SetSimpleColumn(new Phrase(new Chunk("Branch & IFSC Code", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD))),
                                     45, 100, 530, 100, -10, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                ifsc.Go();

                ColumnText ifscVal = new ColumnText(cb);
                ifscVal.SetSimpleColumn(new Phrase(new Chunk(viewmodel.CompanyDetails.BranchName + " - " + viewmodel.CompanyDetails.IFSCCode, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL))),
                                     180, 100, 530, 100, -10, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                ifscVal.Go();


                ColumnText jspsign = new ColumnText(cb);
                jspsign.SetSimpleColumn(new Phrase(new Chunk("For J S P & Associates", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD))),
                                     410, 100, 530, 100, -30, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                jspsign.Go();

                ColumnText jspsignVal = new ColumnText(cb);
                jspsignVal.SetSimpleColumn(new Phrase(new Chunk("Authorised Signatory", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL))),
                                     420, 100, 530, 100, 0, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                jspsignVal.Go();
                myDocument.Close();
                byte[] content = myMemoryStream.ToArray();

                //             Directory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                //             string stringsFile = Path.Combine(Directory, "PDF", Temp+".pdf");
                //             // Write out PDF from memory stream. 



                _SD.FileName = "Test";
                _SD.DefaultExt = ".pdf";
                _SD.Filter = "pdf documents (.pdf)|*.pdf|All files (*.*)|*.*";
                if (_SD.ShowDialog() == true)
                {
                    using (FileStream fs = File.Create(_SD.FileName))
                    {
                        fs.Write(content, 0, (int)content.Length);
                    }

                    System.Diagnostics.Process.Start(_SD.FileName);

                }

            }
            catch (Exception Exp)
            {
                MessageBox.Show(Exp.Message);
            }
            return _SD.FileName;
        }





        private PdfTemplate PdfFooter(PdfContentByte cb, DataRow drFoot)
        {
            // Create the template and assign height
            PdfTemplate tmpFooter = cb.CreateTemplate(580, 70);
            // Move to the bottom left corner of the template
            tmpFooter.MoveTo(1, 1);
            // Place the footer content
            tmpFooter.Stroke();
            // Begin writing the footer
            tmpFooter.BeginText();
            // Set the font and size
            tmpFooter.SetFontAndSize(f_cn, 8);
            // Write out details from the payee table
            tmpFooter.ShowTextAligned(PdfContentByte.ALIGN_LEFT, drFoot["supplier"].ToString(), 0, 53, 0);
            tmpFooter.ShowTextAligned(PdfContentByte.ALIGN_LEFT, drFoot["address1"].ToString(), 0, 45, 0);
            tmpFooter.ShowTextAligned(PdfContentByte.ALIGN_LEFT, drFoot["address2"].ToString(), 0, 37, 0);
            tmpFooter.ShowTextAligned(PdfContentByte.ALIGN_LEFT, drFoot["address3"].ToString(), 0, 29, 0);
            tmpFooter.ShowTextAligned(PdfContentByte.ALIGN_LEFT, drFoot["zip"].ToString() + " " + drFoot["city"].ToString() + " " + drFoot["country"].ToString(), 0, 21, 0);
            // Bold text for ther headers
            tmpFooter.SetFontAndSize(f_cb, 8);
            tmpFooter.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Phone", 215, 53, 0);
            tmpFooter.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Mail", 215, 45, 0);
            tmpFooter.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Web", 215, 37, 0);
            tmpFooter.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Legal info", 400, 53, 0);
            // Regular text for infomation fields
            tmpFooter.SetFontAndSize(f_cn, 8);
            tmpFooter.ShowTextAligned(PdfContentByte.ALIGN_LEFT, drFoot["phone"].ToString(), 265, 53, 0);
            tmpFooter.ShowTextAligned(PdfContentByte.ALIGN_LEFT, drFoot["mail"].ToString(), 265, 45, 0);
            tmpFooter.ShowTextAligned(PdfContentByte.ALIGN_LEFT, drFoot["web"].ToString(), 265, 37, 0);
            tmpFooter.ShowTextAligned(PdfContentByte.ALIGN_LEFT, drFoot["xtrainfo"].ToString(), 400, 45, 0);
            // End text
            tmpFooter.EndText();
            // Stamp a line above the page footer
            cb.SetLineWidth(0f);
            cb.MoveTo(30, 60);
            cb.LineTo(570, 60);
            cb.Stroke();
            // Return the footer template
            return tmpFooter;
        }

    }
    public class PageEventHelper : PdfPageEventHelper
    {
        PdfContentByte cb;
        PdfTemplate template;


        public override void OnOpenDocument(PdfWriter writer, Document document)
        {

            cb = writer.DirectContent;
            template = cb.CreateTemplate(50, 50);
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {

            base.OnEndPage(writer, document);
            BaseFont bf_qty = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            //int pageN = writer.PageNumber;
            //String text = "Page " + pageN.ToString();




            String text = "Page " + 1 + " of ";
            float len = bf_qty.GetWidthPoint(text, 8);
            //float len = this.RunDateFont.BaseFont.GetWidthPoint(text, this.RunDateFont.Size);

            iTextSharp.text.Rectangle pageSize = document.PageSize;

            // cb.SetRGBColorFill(100, 100, 100);

            cb.BeginText();

            //Font font_qty = new Font(bf_qty, 10, Font.NORMAL);
            cb.SetFontAndSize(bf_qty, 10f);
            cb.SetTextMatrix(document.LeftMargin, pageSize.GetBottom(document.BottomMargin));
            // cb.ShowText(text);
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT,
                           "Printed On " + DateTime.Now.ToString(),
                           pageSize.GetRight(40),
                           pageSize.GetBottom(30), 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT,
                                   text,
                                  pageSize.GetLeft(40),
                                  pageSize.GetBottom(30), 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT,
                                           "This is a Computer generated Invoice",
                                          pageSize.GetLeft(200),
                                          pageSize.GetBottom(30), 0);


            cb.EndText();

            // cb.AddTemplate(template, document.LeftMargin, pageSize.GetBottom(document.BottomMargin));

            cb.AddTemplate(template, pageSize.GetLeft(40) + len, pageSize.GetBottom(30));
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);

            template.BeginText();
            BaseFont bf_qty = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            Font font_qty = new Font(bf_qty, 10, Font.NORMAL);
            template.SetFontAndSize(bf_qty, 10f);

            template.SetTextMatrix(10, 0);
            int pageNumber = writer.PageNumber - 1;

            template.ShowText(Convert.ToString(pageNumber));
            template.EndText();

        }

    }
}
