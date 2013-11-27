using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Analisadores
{
    public partial class FormAnalizador : Form
    {
        int x;//Variável x para guardar as posições.
        //Vetores para declarar e salvar símbolos e tókens.
        bool Erro = false;
        int estado = 0;
        public static string[] token = new string[54];
        public static string[] simbolo = new string[54];
        public FormAnalizador()
        {
            InitializeComponent();
            simbolo[1] = "cinInt"; token[1] = "Leitura Inteiro";
            simbolo[2] = "cinDouble"; token[2] = "Leitura Double";
            simbolo[3] = "cinString"; token[3] = "Leitura String";
            simbolo[4] = "cinBoolean"; token[4] = "Leitura Booleana";
            simbolo[5] = "||"; token[5] = "OP OR";
            simbolo[6] = "("; token[6] = "Abre parentes";
            simbolo[7] = ")"; token[7] = "fecha parentes ";
            simbolo[8] = "{"; token[8] = "Abre chaves";
            simbolo[9] = "}"; token[9] = "fecha chaves";
            simbolo[10] = "["; token[10] = "Abre colchetes";
            simbolo[11] = "]"; token[11] = "fecha colchetes";
            simbolo[12] = "+"; token[12] = "OP SOMA";
            simbolo[13] = "-"; token[13] = "OP SUBTRAI";
            simbolo[14] = "*"; token[14] = "OP MULTIPLICAÇÃO";
            simbolo[15] = "/"; token[15] = "OP DIVISÃO";
            simbolo[16] = "&&"; token[16] = "OP AND";
            simbolo[17] = "++"; token[17] = "OP SOMAR 1";
            simbolo[18] = "--"; token[18] = "OP SUBTRAIR 1";
            simbolo[19] = "="; token[19] = "OP IGUAL";
            simbolo[20] = "=="; token[20] = "OP IGUAL_IGUAL";
            simbolo[21] = "<="; token[21] = "OP MENOR_IGUAL";
            simbolo[22] = ">="; token[22] = "OP MAIOR_IGUAL";
            simbolo[23] = "<"; token[23] = "OP MENOR";
            simbolo[24] = ">"; token[24] = "OP MAIOR";
            simbolo[25] = "!="; token[25] = "OP DIFERENTE";
            simbolo[26] = "!"; token[26] = "OpUnario EXCLAMAÇÃO";
            simbolo[27] = "&"; token[27] = "simbolo E";
            simbolo[28] = ","; token[28] = "VIRGULA";
            simbolo[29] = ";"; token[29] = "PONTO E VIRGULA";
            simbolo[30] = ":"; token[30] = "DOIS PONTOS";
            simbolo[31] = "\""; token[31] = "Aspas Duplas";
            simbolo[32] = "'"; token[32] = "ASPAS SIMPLES";
            simbolo[33] = "."; token[33] = "PONTO";
            simbolo[34] = "_"; token[34] = "SEPARADOR";
            simbolo[35] = "false"; token[35] = "BOOLEANO";
            simbolo[36] = "true"; token[36] = "BOOLEANO";
            simbolo[37] = "class"; token[37] = "Palavra Reservada";
            simbolo[38] = "return"; token[38] = "Palavra Reservada";
            simbolo[39] = "public"; token[39] = "Palavra Reservada";
            simbolo[40] = "void"; token[40] = "Palavra Reservada";
            simbolo[41] = "main"; token[41] = "Palavra Reservada";
            simbolo[42] = "String"; token[42] = "Palavra Reservada";
            simbolo[43] = "boolean"; token[43] = "Palavra Reservada";
            simbolo[44] = "double"; token[44] = "Palavra Reservada";
            simbolo[45] = "if"; token[45] = "Palavra Reservada";
            simbolo[46] = "else"; token[46] = "Palavra Reservada";
            simbolo[47] = "while"; token[47] = "Palavra Reservada";
            simbolo[48] = "cout"; token[48] = "Palavra Reservada";
            simbolo[49] = "<<"; token[49] = "Palavra Reservada";
            simbolo[50] = "endl"; token[50] = "Palavra Reservada";
            simbolo[51] = "int"; token[51] = "Palavra Reservada";
            simbolo[52] = "new"; token[52] = "Palavra Reservada";
            simbolo[53] = "int"; token[53] = "Palavra Reservada";
        }
        private void Analizar()
        {                     
            string Texto = "";
            int temp=0;
            int linha = 1;
            char[] lista = textboxTexTexto.Text.ToCharArray();//Separar o texto em caracteres e armazenar em uma variável Texto.

            int i = 0; //Variável para percorrer o Texto.
            while (i < lista.Length)
            {
                if (lista[i].ToString() == " " || lista[i].ToString() == "\n" || lista[i].ToString() == "\t" || lista[i].ToString() == "\r")//Caso de espaço segue uma posição
                {
                    temp++;
                    if (lista[i].ToString() == "\n")
                    {
                        x = 0;
                        linha++;
                    }
                }
                //Verificar os estados
                if (i <= lista.Length - 1)
                {
                    if ((AnalizarLetra(lista[i])))
                    {
                    estado=1;
                    }
                    else if  (AnalizarNumero(lista[i]) || (lista[i].ToString() == "-" && AnalizarNumero(lista[i + 1])))
                    {
                     estado=3;
                    }
                    else if (char.IsSymbol(lista[i]) || char.IsSeparator(lista[i]) || char.IsPunctuation(lista[i])) // Verificar se é um simbolo
                    {
                    estado = 0;
                    }
                    else
                    {
                    estado = -1;
                    }

                    switch (estado)
                    {
                        case 1: //Caso de letras                          
                                x = i;//Guarda posição de onde começa .
                                while (AnalizarNumero(lista[i]) || AnalizarLetra(lista[i]))//Repetir enquanto for letra ou numero
                                {
                                    Texto = Texto + lista[i].ToString();
                                    i++;

                                    if (i == lista.Length) break;//Se saímos da Ultina posição porque não há mais nada para analisar
                                }
                                //Verificar se a palavra reservada é um identificador
                                verificarsimbolo(Texto, temp, linha); //Verifica se a palavra estar na lista dos simbolos
                                i--;
                                if (lista[i].ToString() == " " || lista[i].ToString() == "\n" || lista[i].ToString() == "\t" || lista[i].ToString() == "\r")//Caso de espaço segue uma posição
                                {
                                    temp++;
                                    if (lista[i].ToString() == "\n")
                                    {
                                        x = 0;
                                        linha++;
                                    }
                                }
                                if (lista[i].ToString() == "\n")
                                {
                                    linha++;
                                }
                                Texto = "";
                            break;
                        case 3: //Caso Numero                       
                                x = i;//Guarda a posição de onde começa     
                                string Ti = "I";
                                bool verifica = true; //Inicializar uma variável Aux que concatena e forma o texto
                                if (lista[i].ToString() == "-") //si es que primero empieza con un -
                                {
                                    Texto = Texto + lista[i].ToString();
                                    i += 1;
                                }
                                while (AnalizarNumero(lista[i])) //Repetida enquanto for numero
                                {
                                    Texto = Texto + lista[i].ToString();                                   
                                    i++;                                    
                                    if (i < lista.Length - 1) //Inserir, desde que ele não seja o último caracter da fonte de texto
                                    {
                                        if (lista[i] == '.' && AnalizarNumero(lista[i + 1]) && verifica) // 
                                        {
                                            Texto = Texto + lista[i].ToString();
                                            verifica = false;
                                            Ti = "D";
                                            i++;
                                        }
                                    }
                                    if (i == lista.Length) break;
                                }
                                if (i < lista.Length)
                                {
                                    if (AnalizarLetra(lista[i]) || (char.IsSymbol(lista[i]) || char.IsSeparator(lista[i]) || char.IsPunctuation(lista[i])))
                                    {
                                        i--;
                                    }
                                }
                                //Mostrar o numero  
                                if (Ti == "I") //Se numero Inteiro
                                {
                                    x = x - temp;
                                    dataGridView1.Rows.Add(Texto.ToString(), "NUMERO INTEIRO", (x + 1).ToString(), linha);
                                    Texto = "";
                                }
                                else //Se numero Decimal
                                {
                                    x = x - temp;
                                    dataGridView1.Rows.Add(Texto.ToString(), "NUMERO REAL", (x + 1).ToString(), linha);
                                    Texto = "";
                                }
                                if (Texto != " ")
                                {
                                    verificarsimbolo(Texto, temp, linha);
                                    Texto = "";
                                }                                    
                            break;
                        case 0: //Caso Simbolo
                                x = i;
                                if (i < lista.Length - 1)
                                {
                                    int estadoSimbolo = estado;
                                    string c = lista[i].ToString();
                                    string cProximo = lista[i + 1].ToString();

                                    if (c == "=")
                                    {
                                        estadoSimbolo = 9;
                                    }
                                    else if (c == "|")
                                    {
                                        estadoSimbolo = 11;
                                    }
                                    else if (c == "&")
                                    {
                                        estadoSimbolo = 13;
                                    }
                                    else if (c == "<" )
                                    {
                                        estadoSimbolo = 15;
                                    }
                                    else if (c == ">" )
                                    {
                                        estadoSimbolo = 17;
                                    }
                                    else if (c == "!")
                                    {
                                        estadoSimbolo = 19;
                                    }
                                    else if (c == "/")
                                    {
                                        if (cProximo == "/")
                                        {
                                            estadoSimbolo = 21;
                                        }
                                        else if (cProximo == "*")
                                        {
                                            estadoSimbolo = 23;
                                        }
                                    }
                                    else if (c == "'")
                                    {
                                        estadoSimbolo = 24;
                                    }
                                    else if (c == "\"")
                                    {
                                        estadoSimbolo = 25;
                                    }
                                    else if (c == "(")
                                    {
                                        estadoSimbolo = 26;
                                    }
                                    else if (c == ")")
                                    {
                                        estadoSimbolo = 27;
                                    }
                                    else if (c == "{")
                                    {
                                        estadoSimbolo = 28;
                                    }
                                    else if (c == "}")
                                    {
                                        estadoSimbolo = 29;
                                    }
                                    else if (c == "[")
                                    {
                                        estadoSimbolo = 30;
                                    }
                                    else if (c == "]")
                                    {
                                        estadoSimbolo = 31;
                                    }
                                    else if (c == "+")
                                    {
                                        estadoSimbolo = 32;
                                    }
                                    else if (c == "-")
                                    {
                                        estadoSimbolo = 33;
                                    }
                                    else if (c == "*")
                                    {
                                        estadoSimbolo = 34;
                                    }
                                    else if (c == "!")
                                    {
                                        estadoSimbolo = 35;
                                    }
                                    else if (c == ",")
                                    {
                                        estadoSimbolo = 36;
                                    }
                                    else if (c == ";")
                                    {
                                        estadoSimbolo = 37;
                                    }
                                    else if (c == ":")
                                    {
                                        estadoSimbolo = 38;
                                    }
                                    else if (c == "'")
                                    {
                                        estadoSimbolo = 39;
                                    }
                                    else if (c == ".")
                                    {
                                        estadoSimbolo = 40;
                                    }
                                    else if (c == "_")
                                    {
                                        estadoSimbolo = 41;
                                    }
                                  
                                    switch (estadoSimbolo)
                                    {
                                        case 9:
                                        case 15:
                                        case 17:
                                        case 19:
                                            if (cProximo == "=")
                                            {
                                                string uniao = c + cProximo;
                                                Analizarsimbolo(uniao, x, linha, temp);
                                                i = i + 2;
                                            }
                                            else
                                            {
                                                Analizarsimbolo(lista[i].ToString(), x, linha, temp);
                                            }
                                            break;
                                        case 11:
                                            if (cProximo == "|")
                                            {
                                                string uniao = c + cProximo;
                                                Analizarsimbolo(uniao, x, linha, temp);
                                                i = i + 2;
                                            }
                                            else
                                            {
                                                Analizarsimbolo(lista[i].ToString(), x, linha, temp);
                                            }
                                            break;
                                        case 13:
                                            if (cProximo == "&")
                                            {
                                                string uniao = c + cProximo;
                                                Analizarsimbolo(uniao, x, linha, temp);
                                                i = i + 2;
                                            }
                                            else
                                            {
                                                Analizarsimbolo(lista[i].ToString(), x, linha, temp);
                                            }
                                            break;
                                        case 21:
                                            if (cProximo == "/")
                                            {
                                                string uniao = "";
                                                x = i;

                                                if (lista[i].ToString() != "\n")
                                                {
                                                    uniao = c+cProximo;
                                                    i += 1;//Incrementa no contador
                                                }                                             
                                                dataGridView1.Rows.Add(uniao.ToString(), "COMENTÁRIO DE UMA LINHA", (x + 1).ToString(), linha);
                                            }
                                            else
                                            {
                                                Analizarsimbolo(lista[i].ToString(), x, linha, temp);
                                            }
                                            break;
                                        case 23:
                                            if (cProximo == "*")
                                            {
                                                string uniao = c + cProximo;
                                                dataGridView1.Rows.Add(uniao, "COMENTÁRIO DE UM PARÁGRAFO", (x + 1).ToString(), linha);
                                                i = i + 1;
                                            }
                                            else
                                            {
                                                Analizarsimbolo(lista[i].ToString(), x, linha, temp);
                                            }
                                            break;
                                        case 24:
                                            {
                                                string uniao = c + cProximo;
                                                Analizarsimbolo(uniao, x, linha, temp);
                                                i = i + 2;
                                            }                                           
                                            break;
                                        case 25:
                                                x = i;//Guarda posição de onde começa .
                                                string uniaoCaracter=c;
                                                i++;
                                                while (AnalizarLetra(lista[i]))//Repetir enquanto for letra ou numero
                                                {
                                                    Texto = Texto + lista[i].ToString();
                                                    i++;

                                                    if (i == lista.Length) break;//Se saímos da Ultina posição porque não há mais nada para analisar
                                                }
                                                if (lista.Length < i)
                                                {
                                                    c = lista[i].ToString();                                                   
                                                }
                                                uniaoCaracter = uniaoCaracter + Texto;
                                            if (c == "\"")
                                            {
                                                uniaoCaracter = uniaoCaracter + c;
                                                dataGridView1.Rows.Add(uniaoCaracter, "String", (x + 1).ToString(), linha);
                                                Texto = "";
                                            }
                                             else
                                            {
                                                dataGridView1.Rows.Add(uniaoCaracter, "ERRO", (x + 1).ToString(), linha);
                                            }                                            
                                            break;
                                        case 26:
                                        case 27:
                                        case 28:
                                        case 29:
                                        case 30:
                                        case 31:
                                        case 32:
                                        case 33:
                                        case 34:
                                        case 35:
                                        case 36:
                                        case 37:
                                        case 38:
                                        case 39:
                                        case 40:
                                        case 41:
                                        case 42:
                                            Analizarsimbolo(lista[i].ToString(), x, linha, temp);
                                            break;
                                        case 5:
                                            {
                                                Analizarsimbolo(lista[i].ToString(), x, linha, temp);
                                            }
                                            break;
                                    }
                                }
                                else // Senão simbolo unitário
                                {
                                    Analizarsimbolo(lista[i].ToString(), x, linha, temp);
                                    i = i + 1;
                                }                            
                            break;
                        case -1:                          
                             x = i;
                     
                                if (lista[i].ToString() == " " || lista[i].ToString() == "\n" || lista[i].ToString() == "\t" || lista[i].ToString() == "\r")//Caso de espaço segue uma posição
                                {
                                    temp++;
                                    if (lista[i].ToString() == "\n")
                                    {
                                        linha++;
                                    }
                                }
                                Analizarsimbolo(lista[i].ToString(), x, linha,temp);
                            Texto = "";
                            break;
                    }
                    i++;
                    }
                    labelResultadoAnalise.Text = (Erro) ? "Análise Léxica INCORRETA" : "Análise Léxica CORRETA";
                }
            }
        private void Analizarsimbolo(string uniao, int posSimbolo,int linha,int temp)
        {
            int flag = -1;
            int Pos = -1;
            for (int i = 0; i < simbolo.Length; i++)
            {
                if (simbolo[i] == uniao)
                {
                    flag = 1;
                    Pos = i;
                    break;
                }
            }
            //Verifica se simbola pertence a lista
            posSimbolo = posSimbolo - temp;
            if (flag > -1)
            {

                dataGridView1.Rows.Add(uniao.ToString(), token[Pos], (posSimbolo + 1).ToString(),linha);
            }
            else
            {
                if (uniao != " ")
                {
                    Erro = true;
                    dgvErro.Visible = true;
                    labelErros.Visible = true;
                    if (uniao != " " && uniao != "\n" && uniao != "\t" && uniao != "\r")//Caso de espaço segue uma posição
                    {
                        dataGridView1.Rows.Add(uniao.ToString(), "simbolo DESCONHECIDO", (posSimbolo + 1).ToString(), linha);
                        dgvErro.Rows.Add("1", uniao.ToString(), (posSimbolo + 1).ToString());
                    }
                }
            }
        }
        private void verificarsimbolo(string Texto,int temp,int linha)
        {
            int flag = -1;
            int Pos = -1;
            for (int i = 0; i < simbolo.Length; i++)
            {
                if (simbolo[i] == Texto)
                {
                    flag = 1;
                    Pos = i;
                    break;
                }
            }
            if (flag > -1) //Verifica se é uma Palavra reservada
            {
                dataGridView1.Rows.Add(Texto.ToString(), token[Pos], (x + 1).ToString(),linha);
            }
            else
            {
                if (Texto.ToString() != "")
                {
                    x = x - temp;
                    dataGridView1.Rows.Add(Texto.ToString(), "ID", (x + 1).ToString(),linha);
                }
            }
        }
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
        private bool AnalizarLetra(char p)
        {
            return char.IsLetter(p) ? true : false;
        }        
        private void btnAnalizar_Click(object sendeBr, EventArgs e)
        {
            if (dataGridView1.RowCount > 0) // Limpar dados da Grid
                dataGridView1.Rows.Clear();
            if (dgvErro.RowCount > 0)
                dgvErro.Rows.Clear();
            Erro = false;
            label1.Text = "";
            Analizar(); //Chamar procedimento Analizar
            labelResultados.Visible=true;
            dataGridView1.Visible = true;
            labelResultadoAnalise.Visible = true;
        }
    }
}