using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security;

namespace Analisadores
{
    public partial class FormAnalizador : Form
    {
        int x;//Variável x para guardar as posições.        
        bool Erro = false;
        int estado = 0;
        int coluna = 0;
        int quantErros = 1;
        //Vetores para declarar e salvar símbolos e tókens.
        public static string[] token = new string[56];
        public static string[] tabela = new string[56];
        public FormAnalizador()
        {
            InitializeComponent();
            tabela[1] = "cinInt"; token[1] = "Leitura Inteiro";
            tabela[2] = "cinDouble"; token[2] = "Leitura Double";
            tabela[3] = "cinString"; token[3] = "Leitura String";
            tabela[4] = "cinBoolean"; token[4] = "Leitura Booleana";
            tabela[5] = "||"; token[5] = "Op or";
            tabela[6] = "("; token[6] = "Abre parentes";
            tabela[7] = ")"; token[7] = "fecha parentes ";
            tabela[8] = "{"; token[8] = "Abre chaves";
            tabela[9] = "}"; token[9] = "fecha chaves";
            tabela[10] = "["; token[10] = "Abre colchetes";
            tabela[11] = "]"; token[11] = "Fecha colchetes";
            tabela[12] = "+"; token[12] = "op soma";
            tabela[13] = "-"; token[13] = "Op subtraI";
            tabela[14] = "*"; token[14] = "Op multiplicação";
            tabela[15] = "/"; token[15] = "Op divisão";
            tabela[16] = "&&"; token[16] = "op and";
            tabela[17] = "<<"; token[17] = "Menor_Menor";
            tabela[18] = ">>"; token[18] = "Maior_Maior";
            tabela[19] = "="; token[19] = "Op igual";
            tabela[20] = "=="; token[20] = "Op igual_igual";
            tabela[21] = "<="; token[21] = "Op menor_igual";
            tabela[22] = ">="; token[22] = "Op maior_igual";
            tabela[23] = "<"; token[23] = "Op menor";
            tabela[24] = ">"; token[24] = "Op maior";
            tabela[25] = "!="; token[25] = "Op diferente";
            tabela[26] = "!"; token[26] = "OpUnario exclamação";
            tabela[27] = "int"; token[27] = "Palavra Reservada";
            tabela[28] = ","; token[28] = "Virgula";
            tabela[29] = ";"; token[29] = "Ponto e virgula";
            tabela[30] = "\""; token[30] = "Aspas Duplas";
            tabela[31] = "."; token[31] = "Ponto";
            tabela[32] = "endl"; token[32] = "Palavra Reservada";
            tabela[33] = "while"; token[33] = "Palavra Reservada";
            tabela[34] = "cout"; token[34] = "Palavra Reservada";
            tabela[35] = "false"; token[35] = "Booleano";
            tabela[36] = "true"; token[36] = "Booleano";
            tabela[37] = "class"; token[37] = "Palavra Reservada";
            tabela[38] = "return"; token[38] = "Palavra Reservada";
            tabela[39] = "public"; token[39] = "Palavra Reservada"; 
            tabela[40] = "void"; token[40] = "Palavra Reservada";
            tabela[41] = "main"; token[41] = "Palavra Reservada";
            tabela[42] = "String"; token[42] = "Palavra Reservada";
            tabela[43] = "boolean"; token[43] = "Palavra Reservada";
            tabela[44] = "double"; token[44] = "Palavra Reservada";
            tabela[45] = "if"; token[45] = "Palavra Reservada";
            tabela[46] = "else"; token[46] = "Palavra Reservada";   
        }

        private void Analizar()
        {
            string Texto = "";           
            int linha = 1; // Contador de linha
            char[] lista = textboxTexTexto.Text.ToCharArray(); // Separar o texto em caracteres e armazenar em uma variável Texto.
            int i = 0; // Variável para percorrer o Texto.            

            while (i < lista.Length)
            {
                if (lista[i].ToString() == "\n" || lista[i].ToString() == "\t" || lista[i].ToString() == "\r") // Soma linha
                {
                    if (lista[i].ToString() == "\n")
                    { x = 0; linha++; }
                }

                //Verificar os estados
                if (i <= lista.Length - 1)
                {
                    if (char.IsSymbol(lista[i]) || char.IsSeparator(lista[i]) || char.IsPunctuation(lista[i])) // Caso Simbolo
                    {estado = 0;} // Nao faz nada

                    else if ((AnalizarLetra(lista[i])))
                    { estado = 1; } // Caso Letra
                    else if (AnalizarNumero(lista[i]))
                    { estado = 3; } // Caso Número
                    else  
                    {estado = -1;}

                    switch (estado)
                    {
                        case 1:                          
                            x = i; // Guarda posição de onde começa .
                            while (AnalizarNumero(lista[i]) || AnalizarLetra(lista[i])) // Repetir enquanto for letra ou numero
                            {
                                Texto = Texto + lista[i].ToString();
                                i++;
                                if (i == lista.Length) break; // Sair da Ultina posição caso não há mais nada para analisar
                            }
                            
                            verificartabela(Texto, i, linha); // Verificar se a palavra é reservada ou simbolo 
                            i--;
                            // Caso de espaço ou quebra de linha segue uma posição
                            if (lista[i].ToString() == " " || lista[i].ToString() == "\n" || lista[i].ToString() == "\t" || lista[i].ToString() == "\r")
                            {                                
                                if (lista[i].ToString() == "\n") {x = 0;linha++;}
                            }
                            if (lista[i].ToString() == "\n") {linha++;}
                            Texto = "";
                            break;

                        case 3:
                             x = i;
                             // Repetir enquanto for numero
                            while (AnalizarNumero(lista[i]) )
                            {
                                Texto = Texto + lista[i].ToString();
                                i++;
                                // Inserir, desde que ele não seja o último caracter da fonte de texto
                                if (i < lista.Length - 1) 
                                {
                                    if (lista[i] == '.' && AnalizarNumero(lista[i + 1])) // Caso formar numero real. 
                                    {
                                        Texto = Texto + lista[i].ToString();
                                        estado = 5;
                                        i++;
                                    }
                                }
                                if (i == lista.Length) break;
                            }                           
                            if ( i < lista.Length)
                            {
                            if (lista[i].ToString() == " " || lista[i].ToString() == "\n" || lista[i].ToString() == "\t" || lista[i].ToString() == "\r")//Caso de espaço segue uma posição
                            {
                                if (lista[i].ToString() == "\n"){x = 0; linha++;}
                            }
                            if (lista[i].ToString() == "\n"){linha++; }}

                            coluna = VerificarColuna(Texto.ToString(), i, linha, 0);

                              if (estado == 3) // Se numero Inteiro
                            {
                                dataGridView1.Rows.Add(Texto.ToString(), "ConstInteira", coluna, linha);
                                Texto = "";
                            }
                            else if (estado == 5) // Se numero Decimal
                            {
                                dataGridView1.Rows.Add(Texto.ToString(), "ConstReal", coluna, linha);
                                Texto = "";
                            }
                            if (Texto != " ")
                            {
                                verificartabela(Texto, x, linha);
                                Texto = "";
                            }
                            Texto = "";
                            break;
                     
                        case 0: // Caso Símbolo, atribui os estados
                            x = i;
                            if (i < lista.Length - 1)
                            {
                                int estadotabela = estado;
                                string c = lista[i].ToString();

                                string cProximo = "";
                                if (i < lista.Length){cProximo = lista[i + 1].ToString();}

                                if (c == "=") { estadotabela = 27;}
                                else if (c == "|"){estadotabela = 11;}
                                else if (c == "&"){ estadotabela = 36;}
                                else if (c == "<") { estadotabela = 24; }
                                else if (c == ">") { estadotabela = 30; }
                                else if (c == "!") { estadotabela = 39; }
                                else if (c == "/")
                                {
                                    if (cProximo == "/") { estadotabela = 21; }
                                    else if (cProximo == "*") { estadotabela = 10; }
                                }
                                else if (c == "'") { estadotabela = 42; }
                                else if (c == "\"") { estadotabela = 7; }
                                else if (c == "(") { estadotabela = 15; }
                                else if (c == ")") { estadotabela = 16; }
                                else if (c == "{") { estadotabela = 20; }
                                else if (c == "}") { estadotabela = 19; }
                                else if (c == "[") { estadotabela = 18; }
                                else if (c == "]") { estadotabela = 17; }
                                else if (c == "+") { estadotabela = 33; }
                                else if (c == "-") { estadotabela = 34; }
                                else if (c == "*") { estadotabela = 35; }
                                else if (c == "!") { estadotabela = 35; }
                                else if (c == ";") { estadotabela = 37; }
                                                                
                                switch (estadotabela)
                                {
                                    case 27:
                                    case 30:
                                    case 39:
                                    case 11:
                                    case 36:
                                    case 24:
                                        if ((cProximo == "=") || (cProximo == "|") || (cProximo == "&") || (cProximo == "<") || (cProximo == ">"))
                                        {
                                            string uniao = c + cProximo;
                                            Analizartabela(uniao, x, linha);
                                            i = i + 2;
                                        }
                                        else{Analizartabela(lista[i].ToString(), x, linha);}
                                        break;                                  
                                   
                                    case 21:
                                        if (cProximo == "/")
                                        {
                                            estado = 22;
                                            string uniao = "";
                                            x = i;

                                            if (lista[i].ToString() != "\n")
                                            {
                                                uniao = c + cProximo;
                                                i++;
                                            }
                                            // Concatenar texto do vetor Lista
                                            while (AnalizarLetra(lista[i]) || lista[i].ToString() == " " || AnalizarNumero(lista[i]) || (char.IsSymbol(lista[i])) || char.IsSeparator(lista[i]) || char.IsPunctuation(lista[i]))
                                            {
                                                Texto = Texto + lista[i].ToString();
                                                i++;
                                                if (i == lista.Length) break;
                                            }
                                            coluna = VerificarColuna(uniao, x, linha, 0);
                                            dataGridView1.Rows.Add(uniao.ToString(), "comentário de uma linha", coluna, linha);
                                        }
                                        else
                                        {
                                            x = i;
                                            Analizartabela(lista[i].ToString(), x, linha);
                                        }
                                        break;
                                    case 10: // Analise de comentários
                                        if (cProximo == "*")
                                        {
                                            string confere = "";
                                            string uniao = c + cProximo;

                                            if (cProximo == "*")
                                            {
                                                i = i + 2;
                                                uniao = uniao + Texto;

                                                if (i != lista.Length)
                                                {
                                                    while (AnalizarLetra(lista[i]) || lista[i].ToString() == " " || AnalizarNumero(lista[i]) || (char.IsSymbol(lista[i])) || char.IsSeparator(lista[i]) || char.IsPunctuation(lista[i]))
                                                    {
                                                        if (lista[i].ToString() == "*") break;
                                                        Texto = Texto + lista[i].ToString();
                                                        i++;
                                                        if (i == lista.Length) break;
                                                        if (lista[i].ToString() == "*") break;
                                                    }

                                                    if (i == lista.Length){confere = "erro";}
                                                    else{cProximo = lista[i].ToString();}

                                                    if (cProximo == "*")
                                                    {
                                                        i++;
                                                        if (i == lista.Length){confere = "erro";};

                                                        if (confere != "erro")
                                                        {
                                                            uniao = uniao + Texto + cProximo;
                                                            if (i != lista.Length){cProximo = lista[i].ToString();}
                                                            if (cProximo == "/")
                                                            {
                                                                uniao = uniao + cProximo;
                                                                coluna = VerificarColuna(uniao, i, linha,1);
                                                                dataGridView1.Rows.Add(uniao, "Comentário de Parágrafo(s)", coluna, linha);
                                                                i = i++;
                                                            }else{confere = "erro";}
                                                        }
                                                    }
                                                    else{confere = "erro";}
                                                }else{confere = "erro";}

                                                if (confere == "erro")
                                                {
                                                    uniao = uniao + Texto;
                                                    coluna = VerificarColuna(uniao, i, linha,1);
                                                    dgvErro.Rows.Add(uniao, "Erro Léxico - Faltou Fechar comentário de Paragrafo(s)", coluna, linha);
                                                    dgvErro.Visible = true;
                                                    labelErros.Visible = true;
                                                    labelQuantErros.Visible = true;
                                                    Erro = true;
                                                    quantErros++;
                                                }
                                                uniao = "";
                                                Texto = "";
                                                cProximo = "";
                                            }
                                        }
                                        break;                                    
                                    case 7:
                                        x = i;
                                        string uniaoCaracter = c;
                                        string confereErro = "";
                                        i++;
                                        while (AnalizarLetra(lista[i]) || lista[i].ToString() == " " || AnalizarNumero(lista[i]) || (char.IsSymbol(lista[i])) || char.IsSeparator(lista[i]) || char.IsPunctuation(lista[i]))//Repetir enquanto for letra ou numero
                                        {
                                            if (lista[i].ToString() == "\"") break;
                                            Texto = Texto + lista[i].ToString();
                                            i++;
                                            if (i == lista.Length) break;
                                            if (lista[i].ToString() == "\"") break;
                                        }
                                        if (lista.Length < i){c = lista[i].ToString();}

                                        uniaoCaracter = uniaoCaracter + Texto;
                                        coluna = VerificarColuna(uniaoCaracter, x, linha, 0);
                                        if (lista.Length > i)
                                        {
                                            if (lista[i].ToString() == "\"")
                                            {
                                                estado = 8;
                                                uniaoCaracter = uniaoCaracter + c;
                                                dataGridView1.Rows.Add(uniaoCaracter, "ConstString", coluna, linha);
                                                Texto = "";}
                                            else{confereErro = "erro";}
                                        } else{confereErro = "erro";}

                                        if (confereErro == "erro")
                                        {
                                            coluna = VerificarColuna(uniaoCaracter, i, linha, 1);
                                            dgvErro.Rows.Add(uniaoCaracter, "Erro Léxico - Faltou Fecha Aspas", coluna, linha);
                                            dgvErro.Visible = true;
                                            labelErros.Visible = true;
                                            labelQuantErros.Visible = true;
                                            Erro = true;
                                            quantErros++;
                                        }
                                        break;
                                    case 42:
                                    case 15:
                                    case 16:
                                    case 20:
                                    case 19:
                                    case 18:
                                    case 17:
                                    case 33:
                                    case 34:
                                    case 35:
                                    case 37:
                                    case 38:
                                    case 40:
                                    case 41:
                                        Analizartabela(lista[i].ToString(), x, linha);     // Busca descrição do simbolo na tabela
                                        break;
                                    case 0:
                                        {
                                            Analizartabela(lista[i].ToString(), x, linha); // Verifica se caracter é um simbolo ou palavra reservada
                                        }
                                        break;
                                }
                            }
                            else // Senão Símbolo unitário
                            {                             
                                Analizartabela(lista[i].ToString(), x, linha);                             
                            }
                            break;
                        case -1:
                            x = i;
                            Analizartabela(lista[i].ToString(), x, linha);
                            Texto = "";
                            break;
                    }
                    i++;
                }
            } estado = 45;
            if (estado == 45) { dataGridView1.Rows.Add("EOF", "Fim de Arquivo", "-", linha); }
            labelResultadoAnalise.Text = (Erro) ? "Análise Léxica INCORRETA" : "Análise Léxica CORRETA";
            quantErros = 1;
        }

        // Método para analise de Simbolo e palavra reservada
        private void Analizartabela(string uniao, int indice, int linha)
        {
            int flag = -1;
            int Pos = -1;

            // Verifica se simbola pertence a lista 
            for (int i = 0; i < tabela.Length; i++)
            {
                if (tabela[i] == uniao)
                {
                    flag = 1;
                    Pos = i;
                    break;
                }
            }
            // Verifica a posição/coluna
            int coluna = VerificarColuna(uniao, indice, linha, 0);
            // Preenche Grid com informações
            if (flag > -1)
            { 
                dataGridView1.Rows.Add(uniao.ToString(), token[Pos], coluna, linha);
            }
            else
            {
                if ((uniao != " ") && (uniao != "\r") && (uniao != "\n"))
                {
                    Erro = true;
                    dgvErro.Visible = true;
                    labelErros.Visible = true;
                    labelQuantErros.Visible = true;
                    if (uniao != " " && uniao != "\n" && uniao != "\t" && uniao != "\r")//Caso de espaço segue uma posição
                    {
                        dgvErro.Rows.Add(uniao.ToString(), "Carácter Inválido", coluna, linha);                        
                        quantErros++;
                    }
                }
            }
        }

        // Verifica se texto é uma palavra reservada ou um ID
        private void verificartabela(string Texto, int posicao, int linha)
        {
            int flag = -1;
            int Pos = -1;
            // Verifica se simbola pertence a lista 
            for (int i = 0; i < tabela.Length; i++)
            {
                if (tabela[i] == Texto)
                {
                    flag = 1;
                    Pos = i;
                    break;
                }
            }
            if (flag > -1) 
            {
                int coluna = VerificarColuna(Texto.ToString(), posicao, linha, 0);
                dataGridView1.Rows.Add(Texto.ToString(), token[Pos], coluna, linha);
            }
            else
            {
                string id = "";
                int coluna =  VerificarColuna(Texto.ToString(), posicao,linha,0);

                if (VerificarId(Texto.ToString(), posicao)){ id = "PALAVRA RESERVADA";}
                else { id = "ID";}

                if (Texto.ToString() != "") {dataGridView1.Rows.Add(Texto.ToString(), id, coluna, linha);}
            }
        }

        // Método verificar se texto é um número
        private bool AnalizarNumero(char p)
        {
            bool Estado;
            switch (p.ToString())
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9": Estado = true; break;
                default: Estado = false; break;
            }
            return Estado;
        }

        // Método verificar se ID já existe 
        private bool VerificarId(string id, int posicao)
        {
            // Separar o texto em caracteres e posteriormente armazenar em uma variável Texto.
            char[] lista = textboxTexTexto.Text.ToCharArray();
            int i = 0;
            string Texto = "";
            bool Estado = false;
            int count = 0;

            while ( i < posicao)
            {
                // Repetir enquanto for letra ou numero
                while (AnalizarNumero(lista[i]) || AnalizarLetra(lista[i]))
                {
                    Texto = Texto + lista[i].ToString();
                    i++;
                    if (i == lista.Length) break;
                }
                // Caso Texto já estiver reservado
                if (Texto == id){ count = count + 1;}                
                if (i > lista.Length) break;
                if (i == posicao) break;
                Texto = "";
                i++;
            }
            if (count > 1){Estado = true;}
            return Estado;
        }

        // Método verifica a coluna em que o caracter esta
        private int VerificarColuna(string id, int posicao,int linha,int tipo)
        {
            // Separar o texto em caracteres e armazenar em uma variável Texto.
            char[] lista = textboxTexTexto.Text.ToCharArray();
            int i = 0;
            string Texto = "";
            int Estado = 0;
            int count = 1;
            // Enquanto Indice menor que posição da letra que esta sendo analisada
            while (i < posicao)
            {           
                // While para encrementar a posição do Id/Simbolo/Numero enviado
                while (AnalizarLetra(lista[i]) || AnalizarNumero(lista[i]) || (char.IsSymbol(lista[i])) || char.IsSeparator(lista[i]) || char.IsPunctuation(lista[i]))
                {
                    Texto = Texto + lista[i].ToString();
                    if (lista[i].ToString() == " ")
                    {
                        count++;
                        break;  
                    }                   
                    i++;
                    count++;
                    if (i == lista.Length) break;
                }
                // Se Indice maior que a lista, igual a posição atual, igual a quebra de linha, While será interrompido
                if (i >= lista.Length) break;
                if (i == posicao) break;
                if (lista[i].ToString() == "\r" || lista[i].ToString() == "\n"){count = 0;}
                if (i == lista.Length) break;
                i++;                
                Texto = "";
            }
            // Fórmula para caso de linhas maiores que 1
            if (linha > 1) { Estado = (count - Texto.Length)+1 ; }
            else { Estado = count - Texto.Length;}

            // Formula para caso de simbolos
            if (tipo == 1)
            {
                Estado = count - id.Length;
                if (linha > 1) { Estado = (count - id.Length) + 1; }
            }           
            return Estado;
        }          

        // Método para analisar se caracter é uma letra
        private bool AnalizarLetra(char p)
        {
            return char.IsLetter(p) ? true : false;
        }

        private void LerArquivoTexto(string StrArquivo)
        {
            try
            {   // A declaração using fecha o stream no fim do escopo
                using (StreamReader sr = new StreamReader(StrArquivo))
                {
                    String linha;
                    // Ler e exibe as linhas até alcançar o fim do arquivo.
                    while ((linha = sr.ReadLine()) != null)
                    {
                        textboxTexTexto.Text = textboxTexTexto.Text + linha + "\r\n";
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Não é possivel ler o arquivo");
                MessageBox.Show(e.Message);
            }
        }

        private void btnAnalizar_Click(object sendeBr, EventArgs e)
        {
            dgvErro.Visible = false;
            labelErros.Visible = false;
            labelQuantErros.Visible = false;
            if (dataGridView1.RowCount > 0) // Limpar dados da Grid
                dataGridView1.Rows.Clear();
            if (dgvErro.RowCount > 0)
                dgvErro.Rows.Clear();
            Erro = false;
            label1.Text = "";
            Analizar(); // Chamar procedimento Analizar
            labelResultados.Visible = true;
            dataGridView1.Visible = true;
            labelResultadoAnalise.Visible = true;
            labelQuantErros.Text = quantErros.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textboxTexTexto.Text = "";
            LerArquivoTexto(textBoxArquivo.Text);
        }

        private void buttonProcurar_Click(object sender, EventArgs e)
        {
            textBoxArquivo.Text = "";
            this.ofd1.Multiselect = true;
            this.ofd1.Title = "Selecionar Arquivo";
            ofd1.CheckFileExists = true;
            ofd1.CheckPathExists = true;
            ofd1.FilterIndex = 2;
            ofd1.RestoreDirectory = true;
            ofd1.ReadOnlyChecked = true;
            ofd1.ShowReadOnly = true;

            DialogResult dr = this.ofd1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                // Le os arquivos selecionados 
                foreach (String arquivo in ofd1.FileNames)
                {
                    textBoxArquivo.Text += arquivo;
                    try
                    {
                        PictureBox pb = new PictureBox();
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        pb.Height = 100;
                        pb.Width = 100;
                    }
                    catch (SecurityException ex)
                    {
                        MessageBox.Show("Erro Não é possivel abrir este arquivo" + ex.Message);
                    }
                    finally
                    {
                        textboxTexTexto.Text = "";
                        LerArquivoTexto(textBoxArquivo.Text);
                    }
                }
            }
        }

        private void integrantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 box = new AboutBox1();
            box.ShowDialog();
        }

    }
}