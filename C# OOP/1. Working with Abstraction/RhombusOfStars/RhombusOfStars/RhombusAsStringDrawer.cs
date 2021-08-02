using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhombusOfStars
{
    public class RhombusAsStringDrawer
    {
        public string Draw(int countOfStars)
        {
            StringBuilder sb = new StringBuilder();
            DrawTopPart(countOfStars, sb);
            DrawBottomPart(countOfStars, sb);

            return sb.ToString();
        }

        private static void DrawTopPart(int countOfStars, StringBuilder sb)
        {
            for (int star = 1; star <= countOfStars; star++)
            {
                sb.Append(new string(' ', countOfStars - star));
                DrawLineOfStars(star, sb);
            }
        }

        private static void DrawBottomPart(int n, StringBuilder sb)
        {
            for (int star = n - 1; star >= 1; star--)
            {
                sb.Append(new string(' ', n - star));
                DrawLineOfStars(star, sb);
            }
        }

        private static void DrawLineOfStars(int numberofStars, StringBuilder sb)
        {
            for (int star = 1; star <= numberofStars; star++)
            {
                sb.Append('*');

                if (star < numberofStars)
                {
                    sb.Append(' ');
                }
            }

            sb.AppendLine();
        }
    }
}
