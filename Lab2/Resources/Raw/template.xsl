<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

    <!-- Оголошуємо, що на виході має бути HTML -->
    <xsl:output method="html" encoding="UTF-8" indent="yes"/>

    <xsl:template match="/">
        <html>
            <head>
                <meta charset="UTF-8"/>
                <title>Звіт по мешканцях гуртожитку</title>
                <style>
                    body {
                        font-family: Arial, sans-serif;
                        background-color: #f2f2f2;
                        margin: 20px;
                    }
                    h1 {
                        text-align: center;
                        color: #512BD4;
                    }
                    table {
                        width: 100%;
                        border-collapse: collapse;
                        background: white;
                        border-radius: 8px;
                        overflow: hidden;
                    }
                    th, td {
                        padding: 10px;
                        border: 1px solid #ccc;
                        text-align: left;
                    }
                    th {
                        background-color: #dcd0ff;
                        color: #000;
                        font-weight: bold;
                    }
                    tr:nth-child(even) {
                        background-color: #f9f9f9;
                    }
                </style>
            </head>

            <body>
                <h1>Звіт по мешканцях гуртожитку</h1>

                <table>
                    <tr>
                        <th>ПІБ</th>
                        <th>Факультет</th>
                        <th>Кафедра</th>
                        <th>Курс</th>
                        <th>Кімната</th>
                        <th>Дата поселення</th>
                        <th>Дата виселення</th>
                        <th>№ контракту</th>
                    </tr>

                    <!-- Перебір кожного мешканця -->
                    <xsl:for-each select="ListOfResident/Resident">
                        <tr>
                            <td><xsl:value-of select="@Name"/></td>
                            <td><xsl:value-of select="@Faculty"/></td>
                            <td><xsl:value-of select="@Department"/></td>
                            <td><xsl:value-of select="@Course"/></td>
                            <td><xsl:value-of select="@Room"/></td>
                            <td><xsl:value-of select="@ResidenceStart"/></td>
                            <td><xsl:value-of select="@ResidenceEnd"/></td>
                            <td><xsl:value-of select="@ContractNumber"/></td>
                        </tr>
                    </xsl:for-each>

                </table>
            </body>
        </html>
    </xsl:template>

</xsl:stylesheet>
