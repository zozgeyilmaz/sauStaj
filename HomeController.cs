    public void PdfOlustur(fakulteModel model)
        {
            Bolumler bolum = db.Bolumlers.Where(z => z.bolumID == model.bolumID).FirstOrDefault();
            Fakulteler fakulte = db.Fakultelers.Where(z => z.fakulteID == model.fakulteId).FirstOrDefault();
            Donemler donem = db.Donemlers.Where(k => k.donemID == model.donemID).FirstOrDefault();

            List<tum> ogrA = db.tums.Where(x => x.fakulte == fakulte.fakulteAdi &&
                                                x.bolum == bolum.bolumAdi &&
                                                x.donem == bolum.bolumAdi).ToList();


            iTextSharp.text.Document pdfDosya = new iTextSharp.text.Document(PageSize.A4.Rotate(), 0, 0, 65, 35);//L,R,T,B
            int i = 0; // ogrA icin index
            string path = "C:\\Users\\Pc\\source\\repos\\WebApplication8" + ogrA[i].bolum.ToLower() + "_" + ogrA[i].donem + "Donemi_Sertifikaları.pdf";
            PdfWriter.GetInstance(pdfDosya, new FileStream(path, FileMode.Create));

            // Logolar icin tanimlanan imageler
            iTextSharp.text.Image imgKosgeb = iTextSharp.text.Image.GetInstance("C:\\Users\\Pc\\source\\repos\\WebApplication8\\kosgeb.png");
            imgKosgeb.ScaleAbsolute(120f, 140f);

            iTextSharp.text.Image imgSaüLogo = iTextSharp.text.Image.GetInstance("C:\\Users\\Pc\\source\\repos\\WebApplication8\\saüLogo.png");
            imgSaüLogo.ScaleAbsolute(102f, 120f);

            /////////////////////Bulunmayan fontlarin eklenmesi icin
            int totalfonts = FontFactory.RegisterDirectory("C:\\Windows\\Fonts");
            // yazi tipileri
            // ust baslik icin font
            //iTextSharp.text.pdf.BaseFont font_Turkish = iTextSharp.text.pdf.BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "CP1254", iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);
            //iTextSharp.text.Font girisBaslik = new iTextSharp.text.Font(font_Turkish, 11, iTextSharp.text.Font.BOLD);

            ////
            BaseFont times_news_roman = BaseFont.CreateFont("c:\\Windows\\Fonts\\times.ttf",
            BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            BaseFont times_news_roman_kalin = BaseFont.CreateFont("c:\\Windows\\Fonts\\timesbd.ttf",
            BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            BaseFont bookman_old_s_italic = BaseFont.CreateFont("c:\\Windows\\Fonts\\BOOKOSI.ttf",
            BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            BaseFont bookman_old_s_normal_kalin = BaseFont.CreateFont("c:\\Windows\\Fonts\\BOOKOSB.ttf",
            BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            BaseFont bookman_old_s_normal = BaseFont.CreateFont("c:\\Windows\\Fonts\\BOOKOS.ttf",
            BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font girisBaslik = new iTextSharp.text.Font(times_news_roman_kalin, 12f, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font f = new iTextSharp.text.Font(bookman_old_s_normal_kalin, 28f, iTextSharp.text.Font.NORMAL); // Ana baslik icin
            iTextSharp.text.Font f2 = new iTextSharp.text.Font(bookman_old_s_italic, 18f, iTextSharp.text.Font.BOLD); // hitap icin
            iTextSharp.text.Font f3 = new iTextSharp.text.Font(bookman_old_s_italic, 18f, iTextSharp.text.Font.NORMAL); // genel meetin
            iTextSharp.text.Font f4 = new iTextSharp.text.Font(bookman_old_s_normal, 12f, iTextSharp.text.Font.NORMAL, BaseColor.GRAY); // imza
            iTextSharp.text.Font f5 = new iTextSharp.text.Font(times_news_roman, 12f, iTextSharp.text.Font.NORMAL); // dekan ismi
            iTextSharp.text.Font f6 = new iTextSharp.text.Font(bookman_old_s_italic, 12f, iTextSharp.text.Font.NORMAL); // fakulte dekani , TC Kimlik no , Belge Tarihi

            pdfDosya.Open();
            while (i < ogrA.Count)
            {

                // ust baslik icerigi
                String girisBaslik_1 = "KOSGEB";
                String girisBaslik_2 = "KÜÇÜK VE ORTA ÖLÇEKLİ İŞLETMELERİ GELİŞTİRME VE DESTEKLEME ";
                String girisBaslik_3 = "İDARESİ BAŞKANLIĞI";
                String girisBaslik_4 = "SAKARYA MÜDÜRLÜĞÜ";

                iTextSharp.text.Paragraph p = new iTextSharp.text.Paragraph();
                p.Add(girisBaslik_1);
                p.Font = girisBaslik;
                p.Alignment = 1; // 1: center
                PdfPTable table = new PdfPTable(6);
                table.LockedWidth = true;
                table.TotalWidth = 765;
                PdfPTable nestedHeader = new PdfPTable(1);
                PdfPCell pCell1 = new PdfPCell();
                pCell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pCell1.AddElement(p);
                pCell1.PaddingTop = 0f;
                pCell1.PaddingBottom = 0f;
                pCell1.PaddingLeft = 13f;
                nestedHeader.AddCell(pCell1);

                iTextSharp.text.Paragraph p1 = new iTextSharp.text.Paragraph();
                p1.Add(girisBaslik_2);
                p1.Font = girisBaslik;
                p1.Alignment = 1; // 1: center
                PdfPCell pCell2 = new PdfPCell();
                pCell2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pCell2.PaddingTop = 0f;
                pCell2.PaddingBottom = 0f;
                pCell2.PaddingLeft = 13f;
                pCell2.AddElement(p1);
                nestedHeader.AddCell(pCell2);

                iTextSharp.text.Paragraph p3 = new iTextSharp.text.Paragraph();
                p3.Add(girisBaslik_3);
                p3.Font = girisBaslik;
                p3.Alignment = 1; // 1: center
                PdfPCell pCell3 = new PdfPCell();
                pCell3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pCell3.PaddingTop = 0f;
                pCell3.PaddingBottom = 0f;
                pCell3.PaddingLeft = 13f;
                pCell3.AddElement(p3);
                nestedHeader.AddCell(pCell3);
                PdfPCell pCellBosluk = new PdfPCell();
                pCellBosluk.Border = iTextSharp.text.Rectangle.NO_BORDER;
                iTextSharp.text.Paragraph pBosluk = new iTextSharp.text.Paragraph();
                pBosluk.Add(" ");
                pCellBosluk.AddElement(pBosluk);
                nestedHeader.AddCell(pCellBosluk);

                iTextSharp.text.Paragraph p4 = new iTextSharp.text.Paragraph();
                p4.Add(girisBaslik_4);
                p4.Font = girisBaslik;
                p4.Alignment = 1; // 1: center
                PdfPCell pCell4 = new PdfPCell();
                pCell4.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pCell4.PaddingTop = 0;
                pCell4.PaddingLeft = 13f;

                pCell4.AddElement(p4);
                nestedHeader.AddCell(pCell4);

                /*   iTextSharp.text.Paragraph p5 = new iTextSharp.text.Paragraph();
                   p5.Add("This is a test! ÇçĞğİıÖöŞşÜü MÜDÜRLÜĞÜ");
                   p5.Font = f;
                   p5.Alignment = 1; // 1: center
                   PdfPCell pCell5 = new PdfPCell();
                   pCell5.PaddingTop = 0;

                   pCell5.AddElement(p5);
                   nestedHeader.AddCell(pCell5);*/



                //table.LockedWidth = true;
                //  KOSGEB
                // KUCUK VE ORTA OLCEKLİ ...
                // İDARESİ B...
                // 
                // SAKARYA MÜD...
                PdfPCell header = new PdfPCell(nestedHeader);
                header.Border = iTextSharp.text.Rectangle.NO_BORDER;
                //kosgeb logo icin tanimlanan cell
                PdfPCell kosgebCell = new PdfPCell();
                kosgebCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                //kosgebCell.Border = iTextSharp.text.Rectangle.ALIGN_RIGHT | iTextSharp.text.Rectangle.BOTTOM_BORDER;
                kosgebCell.AddElement(imgKosgeb);
                kosgebCell.PaddingLeft = 5f;


                table.AddCell(kosgebCell);
                header.Colspan = 4;
                table.AddCell(header);

                //sau logo  icin tanimlanan cell
                PdfPCell sauCell = new PdfPCell();
                sauCell.Border = iTextSharp.text.Rectangle.ALIGN_LEFT;
                //sauCell.Border = iTextSharp.text.Rectangle.ALIGN_BOTTOM;
                sauCell.PaddingLeft = 24f;
                sauCell.AddElement(imgSaüLogo);
                table.AddCell(sauCell);
                PdfPTable nested = new PdfPTable(1);



                /// satir bosluklari icin kullanilacaktir
                Paragraph bosluk = new Paragraph();
                bosluk.Add(" ");
                PdfPCell boslukCell = new PdfPCell();
                boslukCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                boslukCell.AddElement(bosluk);
                nested.AddCell(boslukCell);


                string anaBaslik = "KATILIM BELGESİ";
                iTextSharp.text.Paragraph p6 = new iTextSharp.text.Paragraph();
                p6.Add(anaBaslik);
                p6.Font = f;
                p6.Alignment = 1; // 1: center
                PdfPCell pCellBody1 = new PdfPCell();
                pCellBody1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                //pCell5.PaddingTop = 0;

                pCellBody1.AddElement(p6);
                nested.AddCell(pCellBody1);

                nested.AddCell(boslukCell);

                //.Hitap ..................................................................................................................


                String Kisi = "Sn. " + ogrA[i].ad + " " + ogrA[i].soyad;

                //Chunk olacak bölüm , Akademik yil ve donem  vei tabanindan alinacaktir.
                iTextSharp.text.Paragraph p7 = new iTextSharp.text.Paragraph();
                p7.Add(Kisi);
                p7.Font = f2;
                p7.Alignment = 1; // 1: center
                PdfPCell pCellBody2 = new PdfPCell();
                pCellBody2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                //pCell5.PaddingTop = 0;

                pCellBody2.AddElement(p7);
                nested.AddCell(pCellBody2);
                //.........................................................................................................................
                nested.AddCell(boslukCell);

                //..Ana metin  ............................................................................................................
                string univ = "     Sakarya Üniversitesi ";
                string egitimDonemi = " " + ogrA[i].donem + " "; // veri tabanından cekilecek
                string akademikYili = " Akademik yılı ";
                string donemD = " " + ogrA[i].donem + " "; // veri tabanindan alinacak  
                string metin = " döneminde SAU012 kodlu Girişimcilik ve Proje Yönetimi dersini başarı ile tamamlamıştır.";
                // Sakarya Üniversitesi 2016-2017 Akademik yılı Bahar döneminde SAU012 kodlu Girişimcilik ve Proje Yönetimi dersini başarı ile tamamlamıştır. 
                Chunk chunkUniv = new Chunk(univ, f3);
                Chunk chunkEgitimDonemi = new Chunk(egitimDonemi, f3);
                Chunk chunkAkademik = new Chunk(akademikYili, f3);
                Chunk chunkDonem = new Chunk(donemD, f3);
                Chunk chunkMetin = new Chunk(metin, f3);
                Paragraph paragMetin = new Paragraph();
                paragMetin.Add(chunkUniv);
                paragMetin.Add(chunkEgitimDonemi);
                paragMetin.Add(chunkAkademik);
                paragMetin.Add(chunkDonem);
                paragMetin.Add(chunkMetin);
                paragMetin.Alignment = 1;
                PdfPCell pCellBodyMetin = new PdfPCell();
                pCellBodyMetin.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pCellBodyMetin.PaddingRight = 20f;

                pCellBodyMetin.AddElement(paragMetin);
                nested.AddCell(pCellBodyMetin);
                //.........................................................................................................................

                nested.AddCell(boslukCell);
                nested.AddCell(boslukCell);

                //..İmza  .................................................................................................................
                string imza = "(imza)";

                iTextSharp.text.Paragraph pImza = new iTextSharp.text.Paragraph();
                pImza.Add(imza);
                pImza.Font = f4;
                pImza.Alignment = 1; // 1: center
                PdfPCell pCellBody3 = new PdfPCell();
                pCellBody3.Border = iTextSharp.text.Rectangle.NO_BORDER;

                pCellBody3.PaddingBottom = 0;
                pCellBody3.AddElement(pImza);
                nested.AddCell(pCellBody3);
                //.........................................................................................................................

                //..Bolum dekan adi  ......................................................................................................
                string dekan = "Dekan adı"; // veri tabanindan alinacaktir.
                iTextSharp.text.Paragraph pDekanAdi = new iTextSharp.text.Paragraph();
                pDekanAdi.Add(dekan);
                pDekanAdi.Font = f5;
                pDekanAdi.Alignment = 1; // 1: center
                PdfPCell pCellBody4 = new PdfPCell();
                pCellBody4.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pCellBody4.PaddingTop = 0;
                pCellBody4.PaddingBottom = 0;
                pCellBody4.AddElement(pDekanAdi);
                nested.AddCell(pCellBody4);
                //.........................................................................................................................

                //..Bolum ve unvan  .......................................................................................................
                string fakulteD = ogrA[i].fakulte;


                iTextSharp.text.Paragraph pfakulte = new iTextSharp.text.Paragraph();
                pfakulte.Add(fakulteD);
                pfakulte.Font = f6;
                pfakulte.Alignment = 1; // 1: center
                PdfPCell pCellBody5 = new PdfPCell();
                pCellBody5.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pCellBody5.PaddingBottom = 0;
                pCellBody5.PaddingTop = 0;

                pCellBody5.AddElement(pfakulte);
                nested.AddCell(pCellBody5);
                //.........................................................................................................................
                nested.AddCell(boslukCell);
                nested.AddCell(boslukCell);


                //..TC Kimlik No   ........................................................................................................
                string TCAciklama = "Katılımcı T.C. Kimlik No: ";
                String tcNo = " " + ogrA[i].tcno; // veri tabanindan gelecek
                Chunk chunkTcAciklama = new Chunk(TCAciklama, f6);
                Chunk chunkTcNo = new Chunk(tcNo, f6);
                Paragraph paragTc = new Paragraph();
                paragTc.Add(chunkTcAciklama);
                paragTc.Add(chunkTcNo);
                PdfPCell pCellTc = new PdfPCell();
                pCellTc.PaddingBottom = 0;
                pCellTc.Border = iTextSharp.text.Rectangle.NO_BORDER;

                pCellTc.AddElement(paragTc);
                nested.AddCell(pCellTc);
                //.........................................................................................................................

                //..Belge Tarihi    .......................................................................................................
                string belgeTarihi = "Belge Tarihi      : ";
                string tarih = "tarih gelecek"; // tarih neye gore belirlenecek
                Chunk chunkBelgeTarihi = new Chunk(belgeTarihi, f6);
                Chunk chunkTarih = new Chunk(tarih, f6);
                Paragraph paragBelgeTarihi = new Paragraph();
                paragBelgeTarihi.Add(chunkBelgeTarihi);
                paragBelgeTarihi.Add(chunkTarih);
                PdfPCell pCellBelge = new PdfPCell();
                pCellBelge.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pCellBelge.PaddingTop = 0;
                pCellBelge.AddElement(paragBelgeTarihi);
                nested.AddCell(pCellBelge);
                //.........................................................................................................................



                PdfPCell nesthousing = new PdfPCell(nested);
                nesthousing.Colspan = 6;
                nesthousing.BorderWidth = 0f;
                //nesthousing.Padding = 0f;

                table.AddCell(nesthousing);




                PdfPTable table1 = new PdfPTable(1);
                PdfPCell edge1 = new PdfPCell(table);
                //edge1.BorderWidth = 2.1f;
                edge1.Padding = 2.5f;


                table1.AddCell(edge1);

                PdfPCell cell = new PdfPCell();
                PdfPTable table0 = new PdfPTable(1);
                table1.LockedWidth = true;
                table1.TotalWidth = 770f;

                PdfPCell edge0 = new PdfPCell(table1);
                edge0.BorderWidth = 2.2f;
                edge0.Padding = 3f;


                table0.AddCell(edge0);

                table0.LockedWidth = true;
                table0.TotalWidth = 775f;

                PdfPTable tableD = new PdfPTable(1);

                tableD.LockedWidth = true;
                tableD.TotalWidth = 780f;
                PdfPCell edgeD = new PdfPCell(table0);
                edgeD.Padding = 2.6f;
                tableD.AddCell(edgeD);



                string FRMTarih = "FRM.03.01.16/03"; // nasil düzenleniyor ?


                Paragraph paragFRMTarihi = new Paragraph();
                paragFRMTarihi.Add("\n");
                //paragFRMTarihi.Add("\n");
                paragFRMTarihi.Add(FRMTarih);
                paragFRMTarihi.Font = f5;


                string revTarih = "Rev. Tarihi: "; // rev tarih neye gore belirlenecek
                string revTarihDevam = "16/05/2016";
                Chunk chunkRevTarihi = new Chunk(revTarih, f5);
                Chunk chunkRevTarih = new Chunk(revTarihDevam, f5);
                Paragraph paragRevTarihi = new Paragraph();
                paragRevTarihi.Add(chunkRevTarihi);
                paragRevTarihi.Add(chunkRevTarih);
                paragRevTarihi.Font = f5;
                paragRevTarihi.PaddingTop = 0f;
                PdfPCell pCellRevTarihi = new PdfPCell();

                pCellRevTarihi.AddElement(paragRevTarihi);
                nested.AddCell(pCellRevTarihi);

                PdfPTable altyazi = new PdfPTable(1);
                altyazi.LockedWidth = true;
                altyazi.TotalWidth = 775f;
                PdfPCell cellAltYazi = new PdfPCell();
                //cellAltYazi.PaddingRight = 500f;
                cellAltYazi.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cellAltYazi.AddElement(paragFRMTarihi);
                cellAltYazi.AddElement(paragRevTarihi);
                altyazi.AddCell(cellAltYazi);

                //pdfDosya.Add(img);
                pdfDosya.Add(tableD);
                pdfDosya.Add(altyazi);

            
                i++;

            }
            pdfDosya.Close();

        }
