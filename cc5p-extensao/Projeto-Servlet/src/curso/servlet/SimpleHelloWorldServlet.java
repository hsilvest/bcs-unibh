package curso.servlet;

import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

@SuppressWarnings("serial")
public class SimpleHelloWorldServlet extends HttpServlet {

	@Override
	protected void doGet(HttpServletRequest req, HttpServletResponse resp)
			throws ServletException, IOException {
			execute(req, resp);
	}

	@Override
	protected void doPost(HttpServletRequest req, HttpServletResponse resp)
			throws ServletException, IOException {
			execute(req, resp);
	}
	protected void execute(HttpServletRequest req, HttpServletResponse resp)
		throws ServletException, IOException {
			//Cabeçalho da resposta
			resp.setContentType("text/html");
			PrintWriter out = resp.getWriter();
			out.print("<html>" + 
					  "<head>" + 
					  "<title> Simple Hello World</title>" + 
					  "</head>" +
					  "<body> <h1> Simples <i>Hello</i> <b>World</b></h1> </body>" +
					  "</html>");
	}
}
