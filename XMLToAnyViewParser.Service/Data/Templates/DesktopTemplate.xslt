<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="/form">

    <WrapPanel xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" Orientation="Vertical">
      <!-- parsing textboxes -->
      <xsl:for-each select="./textbox">
        <xsl:if test="./id = 'password'">
          <TextBlock Text="{./description}"/>
          <TextBox Name="{./id}" Height ="25" Width="150">
            <TextBox.Text>
              <Binding Path="{./description}"/>
            </TextBox.Text>
          </TextBox>
        </xsl:if>

        <xsl:if test="./id != 'password'">
          <TextBlock Text="{./description}"/>
          <TextBox Name="{./id}" Height ="25" Width="150">
            <TextBox.Text>
              <Binding Path="{./description}"  />
            </TextBox.Text>
          </TextBox>
        </xsl:if>

      </xsl:for-each>

      <!-- parsing buttons -->

      <xsl:for-each select="./button">
        <xsl:if test="./id = 'submit'">
          <Button Name="{./id}" Content="{./description}">
            <Button.Command>
              <Binding Path="SubmitCommand"/>
            </Button.Command>
          </Button>
        </xsl:if>

        <xsl:if test="./id != 'submit'">
          <Button Name="{./id}" Content="{./description}">
            <Button.Command>
              <Binding Path="{./commandName}"/>
            </Button.Command>
          </Button>
        </xsl:if>
      </xsl:for-each>
    </WrapPanel>

  </xsl:template>
</xsl:stylesheet>