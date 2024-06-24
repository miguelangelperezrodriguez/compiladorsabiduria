// See https://aka.ms/new-console-template for more information

int inferior,superior;
string line1,line2;
string lineacaminos;
int suma;

Console.WriteLine("Comp. Sabiduria");
Console.WriteLine("Comp. ATLANTE");


// SABIDURIA. Continuo
// 6 :      1 o 2 :     7   8
// 7 :      1 o 2 :     8   9   
// 8 :      1 o 2 :     9   10 ...      

suma=0;
StreamReader sr = new StreamReader("programa.sab");
line1=sr.ReadLine();
line2=sr.ReadLine();

inferior=int.Parse(line1);
superior=int.Parse(line2);

if (inferior>=superior)
    Environment.Exit(0);

Console.WriteLine(inferior.ToString() + "-" + superior.ToString());

lineacaminos=sr.ReadLine();
string[] caminos = lineacaminos.Split(',');

Console.Write(inferior.ToString()+">");
int valor = inferior;
suma=valor;
foreach (string opcion in caminos) 
{
    if (opcion=="1") 
    {
        valor=valor+1;
    }
    if (opcion=="2") 
    {
        valor=valor+2;
    }
    if (valor>superior+2)
        Environment.Exit(0);
    suma+=valor;
    Console.Write(valor.ToString()+">");
}
Console.WriteLine("SUMA :" + suma.ToString());
// ATLANTE : Fásico
// 1 :          1   2               Entradas  1 2
// 2 :          3   4               Entradas  3 4           NIVEL 1
// 3 :          1   2   3   4       Entradas  1 2 3 4 ...   NIVEL 2
// 4 :          5   6
// 5 :          3   4   5   6
// 6 :          7   8 
// 7 :          5   6   7   8
string[] faseatlante = new string[100];
const int maxAtlante = 100;
string fase;
int nivel=1;
faseatlante[0]="1,2,0,0";

for (int i=2;i<=maxAtlante;i++)
{
    fase="";
    if (nivel==1)
    {
        fase = (i+1).ToString() + "," + 
        (i+2).ToString() + ",0,0";
    }
    else if (nivel==2)
    {
        fase = (i-2).ToString() + "," + 
        (i-1).ToString() + "," + (i).ToString() + "," +
        (i+1).ToString();
    }
    faseatlante[i-1]=fase;     
    nivel++;
    if (nivel>2)
        nivel=1;
    //Console.WriteLine(fase);
}

valor = inferior;
string opcionatlante=faseatlante[valor-1];
string[] aumentos;
Console.Write(inferior.ToString() + ">");
foreach (string opcion in caminos) 
{
    aumentos = opcionatlante.Split(',');
    if ((opcion=="1") && (aumentos[0]!="0")) 
    {
        valor=Int32.Parse(aumentos[0]);
    }
    if ((opcion=="2") && (aumentos[1]!="0")) 
    {
        valor=Int32.Parse(aumentos[1]);
    }
    if ((opcion=="3") && (aumentos[2]!="0")) 
    {
        valor=Int32.Parse(aumentos[2]);
    }
    if ((opcion=="4") && (aumentos[3]!="0")) 
    {
        valor=Int32.Parse(aumentos[3]);
    }
    if (valor>superior+2)
        Environment.Exit(0);
    Console.Write(valor.ToString()+">");
    if (valor>0)
        opcionatlante=faseatlante[valor-1];
}




