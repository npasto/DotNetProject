using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Xml.Xsl;
using System.Text;

/// <summary>
/// Summary description for xmlHelper
/// </summary>
public class xmlHelper
{
    public xmlHelper()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string Transform_XMLFile_With_XSLTFile(string XML_Filename, string XSL_Filename)
    {

        //On charge le fichier XML dans un XmlDocument 

        XmlDocument reader = new XmlDocument();
        reader.Load(XML_Filename);

        //On charge le fichier XSL dans un XmlDocument 

        XmlDocument XSLTDocument = new XmlDocument();
        XSLTDocument.Load(XSL_Filename);


        //Création du lecteur XML 
        XmlNodeReader XSLTDocumentReader = new XmlNodeReader(reader);

        //Création du transformateur XSLT     
        XslCompiledTransform xslt = new XslCompiledTransform();
        xslt.Load(XSLTDocument, null, null);

        //là où sera enregistré la transformation 
        StringBuilder TransformOutput = new StringBuilder();

        //paramètre d'écriture du fichier transformé 
        XmlWriterSettings settings = new XmlWriterSettings();

        //paramètre un peu spécial, consultez msdn 
        settings.ConformanceLevel = ConformanceLevel.Auto;

        //xslt.OutputSettings correspond aux paramètres <xsl:output> dans votre fichier XSL 
        //veillez à bien spécifier la sortie en html <xsl:output method="html" /> autrement 
        //c'est "xml" par défaut et les balises vides (exemple <div></div>) seront transformées 
        //en (</div>)             

        XmlWriter htmlDoc = XmlWriter.Create(TransformOutput, xslt.OutputSettings);
        xslt.Transform(XSLTDocumentReader, null, htmlDoc, new XmlUrlResolver());


        return TransformOutput.ToString();
    }

}
