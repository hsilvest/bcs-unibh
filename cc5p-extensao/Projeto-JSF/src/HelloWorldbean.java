import java.util.Date;


public class HelloWorldbean {
	
	private Date data;

	public Date getData() {
		return data;
	}
	
	public void setData(Date data) {
		this.data = data;
	}

	public HelloWorldbean() {
		this.data = new Date();	}

	
	
}
