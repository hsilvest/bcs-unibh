<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>Somando 2 numeros</title>
</head>
<body>
Digite dois numeros para efetuar a soma <hr>
<form action="/Projeto-Servlet/SomaServlet.curso">
	<input type="text" name="campo1" value= <%=request.getParameter("campo1")%> > <br>
	+ <br>
	<input type="text" name="campo2" value= <%=request.getParameter("campo2")%> > <br> 
	<br>
	<input type="submit" value="somar" >
	<br> <br>
	<input type="text" name="campo3" value= <%=request.getParameter("campo3")%> > <br> 
</form>
</body>
</html>