package curso.servlet;

import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

@SuppressWarnings("serial")
public class SomaServlet extends HttpServlet {

	@Override
	protected void doGet(HttpServletRequest req, HttpServletResponse resp)
			throws ServletException, IOException {
		// TODO Auto-generated method stub
		execute(req, resp);
	}

	@Override
	protected void doPost(HttpServletRequest req, HttpServletResponse resp)
			throws ServletException, IOException {
		// TODO Auto-generated method stub
		execute(req, resp);
	}
	protected void execute(HttpServletRequest req, HttpServletResponse resp)	
	throws ServletException, IOException {
		int campo3 = Integer.parseInt(req.getParameter("campo1")) + Integer.parseInt(req.getParameter("campo2"));
		resp.sendRedirect("SomaServlet.jsp?campo3=" + campo3 + "&campo2=" + Integer.parseInt(req.getParameter("campo2")) + "&campo1=" + Integer.parseInt(req.getParameter("campo1")));
	}
}
