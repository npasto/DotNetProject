<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:template match="/">
  <table>
    <tr>
      <td>
        <xsl:value-of select="myPreferedStock/name"/>=
      </td>
      <td>
        <xsl:value-of select="myPreferedStock/value"/>
      </td>
    </tr>
    
  </table>
</xsl:template>

</xsl:stylesheet> 

