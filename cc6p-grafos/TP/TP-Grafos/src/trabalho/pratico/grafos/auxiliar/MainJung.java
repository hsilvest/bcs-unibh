package trabalho.pratico.grafos.auxiliar;

import java.awt.Color;
import java.awt.Dimension;
import javax.swing.JFrame;

import edu.uci.ics.jung.algorithms.layout.AbstractLayout;
import edu.uci.ics.jung.algorithms.layout.ISOMLayout;
import edu.uci.ics.jung.graph.DirectedGraph;
import edu.uci.ics.jung.graph.DirectedSparseGraph;
import edu.uci.ics.jung.visualization.RenderContext;
import edu.uci.ics.jung.visualization.VisualizationViewer;
import edu.uci.ics.jung.visualization.renderers.Renderer;
import edu.uci.ics.jung.visualization.renderers.Renderer.VertexLabel;

public class MainJung {
	/**
	 * @return
	 */
	/**
	 * @return
	 */
	private static DirectedGraph<String, String> criarGrafo() {
		DirectedGraph<String, String> digrafo = new DirectedSparseGraph<String, String>();
		
		//Grafo utilizado no exemplo da nossa rede de sensores
		
		 digrafo.addEdge("v0-v1", "v0", "v1");
		 digrafo.addEdge("v0-v5", "v0", "v5");
		 digrafo.addEdge("v1-v2", "v1", "v2");
		 digrafo.addEdge("v1-v3", "v1", "v3");
		 digrafo.addEdge("v1-v5", "v1", "v5");
		 digrafo.addEdge("v2-v3", "v2", "v3");
		 digrafo.addEdge("v4-v2", "v4", "v2");
		 digrafo.addEdge("v4-v3", "v4", "v3");
		 digrafo.addEdge("v5-v4", "v5", "v4");
		 
		 //Caminho minimo obtido através da implementação do algoritmo de Dijkstra
//		 digrafo.addEdge("v0-v1", "v0", "v1");
//		 digrafo.addEdge("v1-v2", "v1", "v2");
//		 digrafo.addEdge("v1-v3", "v1", "v3");
//		 digrafo.addEdge("v1-v5", "v1", "v5");
//		 digrafo.addEdge("v5-v4", "v5", "v4");

		return digrafo;
	}

	public static void main(String[] args) {
		DirectedGraph<String, String> digrafo = criarGrafo();
		AbstractLayout<String, String> layout = new ISOMLayout<String, String>(
				digrafo);
		VisualizationViewer<String, String> visualization = new VisualizationViewer<String, String>(
				layout);

		visualization.setPreferredSize(new Dimension(1024, 768));
		visualization.setBackground(Color.white);
		RenderContext<String, String> ctx = visualization.getRenderContext();
		ctx.setVertexShapeTransformer(new TransformaFormaVertices());
		ctx.setVertexFontTransformer(new TransformaFonteVertices());
		ctx.setVertexLabelTransformer(new TransformaRotuloVertices());
		ctx.setVertexStrokeTransformer(new TransformaLinhaVertices());
		ctx.setVertexFillPaintTransformer(new TransformaPreenchimentoVertices());
		ctx.setVertexDrawPaintTransformer(new TransformaCorLinhaVertice());

		VertexLabel<String, String> vl = visualization.getRenderer()
				.getVertexLabelRenderer();
		vl.setPosition(Renderer.VertexLabel.Position.CNTR);
		JFrame frame = new JFrame();
		frame.getContentPane().add(visualization);
		frame.pack();
		frame.setVisible(true);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

	}

}
