//https://ru.stackoverflow.com/questions/269706/%D0%9A%D0%B0%D0%BA-%D1%81%D0%B4%D0%B5%D0%BB%D0%B0%D1%82%D1%8C-%D1%82%D1%80%D0%B5%D1%83%D0%B3%D0%BE%D0%BB%D1%8C%D0%BD%D0%B8%D0%BA-%D0%BF%D0%B0%D1%81%D0%BA%D0%B0%D0%BB%D1%8F-%D1%80%D0%BE%D0%B2%D0%BD%D1%8B%D0%BC
using System;

namespace PascalTriangleNew
{
    class PascalTriangleNew
    {
        private static int strings= 18; //скрытое поле - длина треугольника

        //private int row = 18; //скрытое поле - длина треугольника
        //private int cellWidht = 4;// скрытое поле - ширина поля для вывода
 
        private static int[][] s = new int [strings][];
    

        // найдём самое широкое число
        // по свойству треугольника Паскаля, это число в середине нижнего ряда
        private static int  maxNum;// = s[strings - 1][(strings - 1)/2];
        private static int maxNumWidth;// = Convert.ToString(maxNum).Length;

        public int  getMaxNum()
        {
             maxNum = s[strings - 1][(strings - 1)/2];
             return maxNum; 
        }
        public int  getMaxNumWidh()
        {
             maxNumWidth = Convert.ToString(getMaxNum()).Length;
             return maxNumWidth; 
        }

        public PascalTriangleNew(int str){
           
            createPascalTriangle();
            set_row(str);
           
        }

        //Устанавливает ширину треугольника и оптимальную ширину ячейки
        public void set_row(int str){
            strings = str;
            createPascalTriangle();
          maxNum = s[strings - 1][(strings - 1)/2];
         maxNumWidth = Convert.ToString(maxNum).Length;
        }

        //Возвращает заданную ширину треугольника
        public int get_row(){
            return strings;
        }

        public string spaces(int sp){
            string s = "";
            for ( int i=0; i< sp; i++ ){
                s = s + " ";
            }
            return s;
        }


        public void createPascalTriangle(){
                s = new int [strings][];
                for (int i = 0; i < strings; i++) {  
                    s[i] = new int[i+1]; 
                    s[i][0] = 1;
                    for (int j = 1; j < i; j++) 
                        s[i][j] = s[i-1][j-1] + s[i-1][j];
                    s[i][i] =  1;
                }
        }
        public void PrintPascalTriangle() {
        // теперь цикл вывода
            for (int i = 0; i < strings; i++) {
                // насколько ширина данной колонки не дотягивает до наибольшей?
                // для центрирования делим пополам
                int stringPad = (strings - 1 - i) * (maxNumWidth + 1) / 2;
                if (stringPad > 0){ // не нашёл лучше способа создать строку пробелов
                    Console.Write(spaces(stringPad));
                }
                for (int j = 0; j <= i; j++) {
                    String paddedNum = Convert.ToString(s[i][j]);
                    // центрируем число в своей колонке тоже
                    int totalPad = maxNumWidth - paddedNum.Length;
                    int rPad = totalPad / 2;
                    
                    if (rPad > 0){
                        paddedNum =  spaces(rPad) + paddedNum;
                    }
                                                
                    int lPad = totalPad - rPad;
                    if (lPad > 0)
                        paddedNum = spaces(lPad) + paddedNum;
                   Console.Write(paddedNum);
  
                    if (j < i)
                        Console.Write(" ");
                    else
                        Console.WriteLine();
                }
            }
        }
  


        public static void Main(String[] args){ 
                System.Console.WriteLine("Pascal Triangle Program");
                System.Console.Write("Enter the number of rows: ");
                string input = System.Console.ReadLine();
            try{ 
                int n = Convert.ToInt32(input);
                PascalTriangleNew pt = new PascalTriangleNew(n);
                pt.PrintPascalTriangle();
                }
                catch{
                    System.Console.WriteLine("Число введено неверно");
                }
            
        }
    } 
}  


