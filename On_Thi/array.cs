using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace On_Thi
{
    public class array
    {

        int[] arr = new int[100];
        int i;
        string s1;
        int n = 0;
        string array_created;
        string array_increase;

        public int[] Arr { get => arr; set => arr = value; }
        public string Array_created { get => array_created; set => array_created = value; }
        public string Array_increase { get => array_increase; set => array_increase = value; }

        /*
         * 
         * 
         * 
        public void create_arr(string a)
        {
            string s = a.Trim();
            i = s.LastIndexOf(" ");
            while(i != -1)
            {
                s1 = s.Substring(i);
                s = s.Substring(0, i);
                arr[n] = int.Parse(s1);
                n++;
                i = s.LastIndexOf(" ");
            }
            arr[n] = int.Parse(s);
            s = " ";
            for (int i = n; i >=0 ; i--)
            {
                s = s + " " + arr[i].ToString();
            }
            Array_created = s.Trim();
        }
        *
        * 
        */

        public void create_arr(string a)
        {
            string s = a.Trim();
            i = s.LastIndexOf(" ");
            while(i != -1)
            {
                s1 = s.Substring(i);
                s = s.Substring(0, i);
                arr[n] = int.Parse(s1);
                n++;
                i = s.LastIndexOf(" ");
            }
            arr[n] = int.Parse(s);

            s = " ";
            for (int i = n; i >= 0; i--)
            {
                s = s + " " + arr[i].ToString();
            }
            Array_created = s.Trim();
        }
        
        public void sort_increase(int[] a)
        {
            int tmp;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    tmp = a[i];
                    if (a[j] < a[i])
                    {
                        tmp = a[i];
                        a[i] = a[j];
                        a[j] = tmp;
                    }   
                    // arr = arr + "\t " + Array[j];
                }
            }
            string arr = "";
            for (int i = 0; i < a.Length; i++)
            {
                arr = arr + "  " + a[i].ToString();
            }

            array_increase = arr;

        }
    }
}
