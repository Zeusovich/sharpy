using System.CodeDom;
using System.Windows.Forms;

namespace sharpy
{
    public class Fighter
    {
        public string FirstName { get; set; }
        public string Surname{ get; set; }
        public decimal Rating{ get; set; }
        public decimal Weight{ get; set; }

        public Fighter(string firstName, string surName, decimal rating, decimal weight)
        {
            FirstName = firstName;
            Surname = surName;
            Rating = rating;
            Weight = weight;
        }

        public Fighter()
        {
            FirstName = "";
            Surname = "";
            Rating = 0;
            Weight = 0;
        }

        public int[] Sort()
        {
            int[] rating1 = new int[] { };
            {
                int temp;
                for (int i = 0; i < rating1.Length; i++)
                {
                    for (int j = i + 1; j < rating1.Length; j++)
                    {
                        if (rating1[i] > rating1[j])
                        {
                            temp = rating1[i];
                            rating1[i] = rating1[j];
                            rating1[j] = temp;
                        }                   
                    }            
                }
                return rating1;
            }
            
        }
    }
}