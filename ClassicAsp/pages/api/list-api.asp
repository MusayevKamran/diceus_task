<!--#include file="config/settings.asp"-->

<%
Dim apiUrl
apiUrl = API_BASE_URL & "Contacts/Index"

Dim userToken
userToken = Request.Cookies("token")


' Create an XMLHTTP object
Set xmlhttp = Server.CreateObject("MSXML2.ServerXMLHTTP.6.0")

' Open a connection to the API
xmlhttp.open "GET", apiUrl, False
xmlhttp.setRequestHeader "Content-Type", "application/json"
xmlhttp.setRequestHeader "Authorization", "Bearer " & userToken

' Send the GET request
xmlhttp.send  

Dim jsonResponse, json
jsonResponse = xmlhttp.responseText

Set xmlhttp = Nothing
%>
