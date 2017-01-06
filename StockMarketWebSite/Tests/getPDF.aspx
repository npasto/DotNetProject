<%--

   renvoie du pdf

--%>
<%--
<%@ import Namespace="iTextSharp.text" %>
<%@ import Namespace="iTextSharp.text.pdf" %>
<%@ import Namespace="System.IO" %>

<script language="C#" runat="server">
    
    public void Page_Load(Object sender, EventArgs e) {

        Response.ContentType = "application/pdf";
        Console.WriteLine("Chapter 5 example 7: borders");
        // step 1: creation of a document-object
        Document document = new Document();
        try
        {
            // step 2:
            // we create a writer that listens to the document
            // and directs a PDF-stream to a file 
//            PdfWriter.GetInstance(document, new FileStream("Chap0507.pdf", FileMode.Create));
            PdfWriter.GetInstance(document, Response.OutputStream);
            // step 3: we open the document
            document.Open();
            // step 4: we create a table and add it to the document
            iTextSharp.text.Table table = new iTextSharp.text.Table(3);
            table.BorderWidth = 1;
            table.BorderColor = new Color(0, 0, 255);
            table.Border = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;

            table.Padding = 5;
            table.Spacing = 5;
            Cell cell = new Cell("header");
            cell.Header = true;
            cell.BorderWidth = 3;
            cell.Border = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
            cell.Colspan = 3;
            table.AddCell(cell);
            cell = new Cell("example cell with colspan 1 and rowspan 2");
            cell.Rowspan = 2;
            cell.BorderColor = new Color(255, 0, 0);
            cell.Border = Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
            table.AddCell(cell);
            table.AddCell("1.1");
            table.AddCell("2.1");
            table.AddCell("1.2");
            table.AddCell("2.2");
            table.AddCell("cell test1");
            cell = new Cell("big cell");
            cell.Rowspan = 2;
            cell.Colspan = 2;
            cell.Border = Rectangle.NO_BORDER;
            cell.GrayFill = 0.9f;
            table.AddCell(cell);
            table.AddCell("cell test2");
            document.Add(table);
        }
        catch (DocumentException de)
        {
            Console.Error.WriteLine(de.Message);
        }
        catch (IOException ioe)
        {
            Console.Error.WriteLine(ioe.Message);
        }
        // step 5: we close the document
        document.Close();
        
        //Response.Write(document);   

        
    }

</script>
--%>