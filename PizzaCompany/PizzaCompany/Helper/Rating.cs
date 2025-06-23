using System;
using System.Drawing;
using System.Windows.Forms; 
namespace PizzaCompany.Helper
{
    public class Rating
    {
    public void SetRating(int rating, Panel parentPanel)
{
    rating = Math.Max(1, Math.Min(5, rating));
    parentPanel.Controls.Clear();

    for (int i = 0; i < 5; i++)
    {
        Label starLabel = new Label
        {
            AutoSize = true,
            Text = "☆",
            Font = new Font("Segoe UI", 14),
            ForeColor = i < rating ? Color.Goldenrod : Color.Gray,
            BackColor = Color.Transparent,
            Location = new Point(i * 20 , 0) 
        };

        parentPanel.Controls.Add(starLabel);
    }
    Label ratingText = new Label
    {
        AutoSize = true,
        Text = "rating",
        Font = new Font("Segoe UI", 10),
        ForeColor = Color.White,
        BackColor = Color.Transparent,
        Location = new Point(5 * 20 + 5, 3)
    };

         parentPanel.Controls.Add(ratingText);
      }

        public int GetRatingByKhr(decimal riel, decimal exnhange = 4100)
        {

            decimal rattingriel = riel * exnhange;



            if (rattingriel >= 1_000_000) return 5;
            else if (rattingriel >= 500_000) return 4;
            else if (rattingriel >= 200_000) return 3;
            else if (rattingriel >= 100_000) return 2;
            else return 1;
        }




    }
}
