package trabalho.pratico.grafos.principal;

public class Dijkstra {

   // Implementacao do algoritmo de Dijkstra de Siedwick
	
   public static int [] dijkstra (MainDijkstra G, int s) {
      final int [] dist = new int [G.size()];  
      final int [] pred = new int [G.size()];  
      final boolean [] visited = new boolean [G.size()]; 

      for (int i=0; i<dist.length; i++) {
          dist[i] = Integer.MAX_VALUE;
       }
       dist[s] = 0;
 
       for (int i=0; i<dist.length; i++) {
          final int next = minVertex (dist, visited);
          visited[next] = true;
 
          
 
          final int [] n = G.neighbors (next);
          for (int j=0; j<n.length; j++) {
             final int v = n[j];
             final int d = dist[next] + G.getWeight(next,v);
             if (dist[v] > d) {
                dist[v] = d;
                pred[v] = next;
             }
          }
       }
       return pred;  
    }
 
    private static int minVertex (int [] dist, boolean [] v) {
       int x = Integer.MAX_VALUE;
       int y = -1;   
       for (int i=0; i<dist.length; i++) {
          if (!v[i] && dist[i]<x) {y=i; x=dist[i];}
       }
       return y;
    }
 
    public static void printPath (MainDijkstra G, int [] pred, int s, int e) {
	final java.util.ArrayList<Object> path = new java.util.ArrayList<Object>();
       int x = e;
       while (x!=s) {
          path.add (0, G.getLabel(x));
          x = pred[x];
       }
       path.add (0, G.getLabel(s));
       System.out.println (path);
    }
 
}