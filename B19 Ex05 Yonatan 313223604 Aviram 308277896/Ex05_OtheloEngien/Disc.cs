namespace Ex05_OtheloEngien
{

    public class Disc
    {
        private eColors m_Color;
        private Point m_Location;

        public Disc(eColors i_Color, Point i_Location)
        {
            m_Color = i_Color;
            m_Location = i_Location;
        }

        public void Flip()
        {
            if (m_Color == eColors.Black)
            {
                m_Color = eColors.White;
            }
            else
            {
                m_Color = eColors.Black;
            }
        }

        public int Xargument
        {
            get { return m_Location.x; }
        }

        public int Yargument
        {
            get { return m_Location.y; }
        }

        public eColors Color
        {
            get { return m_Color; }
        }

        public enum eColors
        {
            Black = 'x',
            White = 'o'
        }
    }

}
