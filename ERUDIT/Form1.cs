using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERUDIT
{
    public partial class Эрудит : Form
    {
        Player player = Player.None;
        Direction direction = Direction.None;
        List<char> aviableLittersFirstPlayer = new List<char>();
        List<char> aviableLittersSecondPlayer = new List<char>();
        List<char> TMPaviableLittersFirstPlayer = new List<char>();
        List<char> TMPaviableLittersSecondPlayer = new List<char>();
        Button[] buttonArray;
        Label[,] LabelArray;
        Label[,] TMPLabelArray = new Label[15, 15];
        TableLayoutPanel[,] tableLayoutPanelArray;


        Random rand = new Random();
        int Line = -1;
        int Column = -1;
        string word = "";
        int wordCost = 0;
        int wordMult = 1;
        char[,] litterArray = new char[15, 15];
        char[,] TMPlitterArray = new char[15, 15];

        public Эрудит()
        {
            InitializeComponent();

            buttonArray = new Button[] { button1, button2, button3, button4, button5, button6, button7 };
            LabelArray = new Label[,] {{label5, label6,label7,label8,label9,label10,label11,label12,label13,label14,label15,label16,label17,label18,label19},
                                                {label20, label21, label22, label23, label24, label25, label26, label27, label28, label29, label30, label31, label32, label33, label34},
                                                {label35, label36, label37, label38, label39, label40, label41, label42, label43, label44, label45, label46, label47, label48, label49},
                                                {label50, label51, label52, label53, label54, label55, label56, label57, label58, label59, label60, label61, label62, label63, label64},
                                                {label65, label66, label67, label68, label69, label70, label71, label72, label73, label74, label75, label76, label77, label78, label79},
                                                {label80, label81, label82, label83, label84, label85, label86, label87, label88, label89, label90, label91, label92, label93, label94},
                                                {label95, label96, label97, label98, label99, label100, label101, label102, label103, label104, label105, label106, label107, label108, label109},
                                                {label110, label111, label112, label113, label114, label115, label116, label117, label118, label119, label120, label121, label122, label123, label124},
                                                {label125, label126, label127, label128, label129, label130, label131, label132, label133, label134, label135, label136, label137, label138, label139},
                                                {label140, label141, label142, label143, label144, label145, label146, label147, label148, label149, label150, label151, label152, label153, label154},
                                                {label155, label156, label157, label158, label159, label160, label161, label162, label163, label164, label165, label166, label167, label168, label169},
                                                {label170, label171, label172, label173, label174, label175, label176, label177, label178, label179, label180, label181, label182, label183, label184},
                                                {label185, label186, label187, label188, label189, label190, label191, label192, label193, label194, label195, label196, label197, label198, label199},
                                                {label200, label201, label202, label203, label204, label205, label206, label207, label208, label209, label210, label211, label212, label213, label214},
                                                {label215, label216, label217, label218, label219, label220, label221, label222, label223, label224, label225, label226, label227, label228, label229}};
            tableLayoutPanelArray = new TableLayoutPanel[,] {
                                                {tableLayoutPanel6, tableLayoutPanel7, tableLayoutPanel8, tableLayoutPanel9, tableLayoutPanel10, tableLayoutPanel11, tableLayoutPanel12, tableLayoutPanel13, tableLayoutPanel14, tableLayoutPanel15, tableLayoutPanel16, tableLayoutPanel17, tableLayoutPanel18, tableLayoutPanel19, tableLayoutPanel20},
                                                {tableLayoutPanel21, tableLayoutPanel22, tableLayoutPanel23, tableLayoutPanel24, tableLayoutPanel25, tableLayoutPanel26, tableLayoutPanel27, tableLayoutPanel28, tableLayoutPanel29, tableLayoutPanel30, tableLayoutPanel31, tableLayoutPanel32, tableLayoutPanel33, tableLayoutPanel34, tableLayoutPanel35},
                                                {tableLayoutPanel36, tableLayoutPanel37, tableLayoutPanel38, tableLayoutPanel39, tableLayoutPanel40, tableLayoutPanel41, tableLayoutPanel42, tableLayoutPanel43, tableLayoutPanel44, tableLayoutPanel45, tableLayoutPanel46, tableLayoutPanel47, tableLayoutPanel48, tableLayoutPanel49, tableLayoutPanel50},
                                                {tableLayoutPanel51, tableLayoutPanel52, tableLayoutPanel53, tableLayoutPanel54, tableLayoutPanel55, tableLayoutPanel56, tableLayoutPanel57, tableLayoutPanel58, tableLayoutPanel59, tableLayoutPanel60, tableLayoutPanel61, tableLayoutPanel62, tableLayoutPanel63, tableLayoutPanel64, tableLayoutPanel65},
                                                {tableLayoutPanel66, tableLayoutPanel67, tableLayoutPanel68, tableLayoutPanel69, tableLayoutPanel70, tableLayoutPanel71, tableLayoutPanel72, tableLayoutPanel73, tableLayoutPanel74, tableLayoutPanel75, tableLayoutPanel76, tableLayoutPanel77, tableLayoutPanel78, tableLayoutPanel79, tableLayoutPanel80},
                                                {tableLayoutPanel81, tableLayoutPanel82, tableLayoutPanel83, tableLayoutPanel84, tableLayoutPanel85, tableLayoutPanel86, tableLayoutPanel87, tableLayoutPanel88, tableLayoutPanel89, tableLayoutPanel90, tableLayoutPanel91, tableLayoutPanel92, tableLayoutPanel93, tableLayoutPanel94, tableLayoutPanel95},
                                                {tableLayoutPanel96, tableLayoutPanel97, tableLayoutPanel98, tableLayoutPanel99, tableLayoutPanel100, tableLayoutPanel101, tableLayoutPanel102, tableLayoutPanel103, tableLayoutPanel104, tableLayoutPanel105, tableLayoutPanel106, tableLayoutPanel107, tableLayoutPanel108, tableLayoutPanel109, tableLayoutPanel110},
                                                {tableLayoutPanel111, tableLayoutPanel112, tableLayoutPanel113, tableLayoutPanel114, tableLayoutPanel115, tableLayoutPanel116, tableLayoutPanel117, tableLayoutPanel118, tableLayoutPanel119, tableLayoutPanel120, tableLayoutPanel121, tableLayoutPanel122, tableLayoutPanel123, tableLayoutPanel124, tableLayoutPanel125},
                                                {tableLayoutPanel126, tableLayoutPanel127, tableLayoutPanel128, tableLayoutPanel129, tableLayoutPanel130, tableLayoutPanel131, tableLayoutPanel132, tableLayoutPanel133, tableLayoutPanel134, tableLayoutPanel135, tableLayoutPanel136, tableLayoutPanel137, tableLayoutPanel138, tableLayoutPanel139, tableLayoutPanel140},
                                                {tableLayoutPanel141, tableLayoutPanel142, tableLayoutPanel143, tableLayoutPanel144, tableLayoutPanel145, tableLayoutPanel146, tableLayoutPanel147, tableLayoutPanel148, tableLayoutPanel149, tableLayoutPanel150, tableLayoutPanel151, tableLayoutPanel152, tableLayoutPanel153, tableLayoutPanel154, tableLayoutPanel155},
                                                {tableLayoutPanel156, tableLayoutPanel157, tableLayoutPanel158, tableLayoutPanel159, tableLayoutPanel160, tableLayoutPanel161, tableLayoutPanel162, tableLayoutPanel163, tableLayoutPanel164, tableLayoutPanel165, tableLayoutPanel166, tableLayoutPanel167, tableLayoutPanel168, tableLayoutPanel169, tableLayoutPanel170},
                                                {tableLayoutPanel171, tableLayoutPanel172, tableLayoutPanel173, tableLayoutPanel174, tableLayoutPanel175, tableLayoutPanel176, tableLayoutPanel177, tableLayoutPanel178, tableLayoutPanel179, tableLayoutPanel180, tableLayoutPanel181, tableLayoutPanel182, tableLayoutPanel183, tableLayoutPanel184, tableLayoutPanel185},
                                                {tableLayoutPanel186, tableLayoutPanel187, tableLayoutPanel188, tableLayoutPanel189, tableLayoutPanel190, tableLayoutPanel191, tableLayoutPanel192, tableLayoutPanel193, tableLayoutPanel194, tableLayoutPanel195, tableLayoutPanel196, tableLayoutPanel197, tableLayoutPanel198, tableLayoutPanel199, tableLayoutPanel200},
                                                {tableLayoutPanel201, tableLayoutPanel202, tableLayoutPanel203, tableLayoutPanel204, tableLayoutPanel205, tableLayoutPanel206, tableLayoutPanel207, tableLayoutPanel208, tableLayoutPanel209, tableLayoutPanel210, tableLayoutPanel211, tableLayoutPanel212, tableLayoutPanel213, tableLayoutPanel214, tableLayoutPanel215},
                                                {tableLayoutPanel216, tableLayoutPanel217, tableLayoutPanel218, tableLayoutPanel219, tableLayoutPanel220, tableLayoutPanel221, tableLayoutPanel222, tableLayoutPanel223, tableLayoutPanel224, tableLayoutPanel225, tableLayoutPanel226, tableLayoutPanel227, tableLayoutPanel228, tableLayoutPanel229, tableLayoutPanel230}

                                                };
            foreach (var item in LabelArray)
            {
                item.Text = "";
                item.TextAlign = ContentAlignment.MiddleCenter;
                item.Dock = DockStyle.Fill;
                item.BackColor = Color.Transparent;
                item.Font = new Font("Tahoma", 12, FontStyle.Bold);
            }
            foreach (var item in tableLayoutPanelArray)
            {
                item.BackgroundImage = Properties.Resources.Безымянный;
                item.BackgroundImageLayout = ImageLayout.Stretch;
                item.Margin = new System.Windows.Forms.Padding(0);
                item.Padding = new System.Windows.Forms.Padding(0);
            }
            foreach (var item in buttonArray)
            {
                item.Text = "";
                item.Enabled = false;
            }
            for (int x = 0; x < 15; ++x)
                for (int y = 0; y < 15; ++y)
                {
                    litterArray[x, y] = '\0';
                    TMPlitterArray[x, y] = '\0';
                }
            StartFieldFulling();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            SetPlayer(Player.First);
        }
        private void ActivateButtons(Player name)
        {
            List<char> litters = null;
            switch (name)
            {
                case Player.First:
                    litters = aviableLittersFirstPlayer;
                    break;
                case Player.Second:
                    litters = aviableLittersSecondPlayer;
                    break;
                case Player.None:
                    return;
            }
            int i = 0;
            foreach (var item in litters)
            {
                buttonArray[i].Text = Convert.ToString(item);
                buttonArray[i].Enabled = true;
                buttonArray[i++].Visible = true;
            }
            for (; i < 7; ++i)
            {
                buttonArray[i].Text = "";
                buttonArray[i++].Enabled = false;
            }
        }
        private void FillLitters(Player name)
        {
            switch (name)
            {
                case Player.First:
                    while (aviableLittersFirstPlayer.Count < 7)
                        aviableLittersFirstPlayer.Add(Data.createRandomNumber());
                    aviableLittersFirstPlayer.Sort();
                    break;
                case Player.Second:
                    while (aviableLittersSecondPlayer.Count < 7)
                        aviableLittersSecondPlayer.Add(Data.createRandomNumber());
                    aviableLittersSecondPlayer.Sort();
                    break;
                case Player.None:
                    MessageBox.Show("Никто делает ход");
                    break;
            }
        }
        private void RefillLitters(Player name)
        {
            switch (name)
            {
                case Player.First:
                    foreach (var item in aviableLittersFirstPlayer)
                    { 
                        Data.litterCount[item]++;
                        ++Data.b;
                    }
                    aviableLittersFirstPlayer.Clear();
                    FillLitters(name);
                    break;
                case Player.Second:
                    foreach (var item in aviableLittersSecondPlayer)
                    {
                        Data.litterCount[item]++;
                        ++Data.b;
                    }
                    aviableLittersSecondPlayer.Clear();
                    FillLitters(name);
                    break;
                case Player.None:
                    MessageBox.Show("Никто делает ход");
                    break;
            }
        }
        private char RandomLitter()
        {
            char tmp;
            do tmp = (char)((int)'а' + rand.Next() % 33);
            while (tmp == 'ё' || tmp == 'ѐ');
            return tmp;
        }
        private void SetPlayer(Player name)
        {
            switch (name)
            {
                case Player.First:
                    label1.BackColor = Color.Lime;
                    label2.BackColor = Color.Orange;
                    break;
                case Player.Second:
                    label2.BackColor = Color.Lime;
                    label1.BackColor = Color.Orange;
                    break;
                case Player.None:
                    label1.BackColor = Color.FromArgb(255, 255, 192);
                    label2.BackColor = Color.FromArgb(255, 255, 192);
                    break;
            }
            player = name;
            FillLitters(player);
            ActivateButtons(player);
            Data.interconnectedWithAnotherWord = false;
            direction = Direction.None;
            word = "";
            wordCost = 0;
            wordMult = 1;
            Line = -1;
            Column = -1;

            Array.Copy(litterArray, TMPlitterArray, litterArray.Length);
            Array.Copy(LabelArray, TMPLabelArray, LabelArray.Length);
            TMPaviableLittersFirstPlayer = new List<char>(aviableLittersFirstPlayer);
            TMPaviableLittersSecondPlayer = new List<char>(aviableLittersSecondPlayer);
        }
        private void ResetFieldMarking()
        {
            StartFieldFulling();
            switch (direction)
            {
                case Direction.Horizontal:
                    int x = (Column == -1) ? 0 : Column;
                    if (Line == -1) return;
                    Color color = Point.GetColor(x, Line);
                    if (color == Color.Red) tableLayoutPanelArray[Line, x].BackgroundImage = Properties.Resources.REDBOURD;
                    else if (color == Color.Blue) tableLayoutPanelArray[Line, x].BackgroundImage = Properties.Resources.BLUEBOURD;
                    else if (color == Color.Green) tableLayoutPanelArray[Line, x].BackgroundImage = Properties.Resources.GREENBOURD;
                    else if (color == Color.Yellow) tableLayoutPanelArray[Line, x].BackgroundImage = Properties.Resources.YELLOWBOURD;
                    else if (color == Color.Aquamarine) tableLayoutPanelArray[Line, x].BackgroundImage = Properties.Resources.CENTERBOURD;
                    else tableLayoutPanelArray[Line, x].BackgroundImage = Properties.Resources.WHITE;
                    ++x;
                    for (; x < 15; ++x)
                    {
                        Color brush = Point.MiddleColour(Color.Black, Point.GetColor(x, Line));
                        tableLayoutPanelArray[Line, x].BackColor = brush;
                        tableLayoutPanelArray[Line, x].BackgroundImage = null;
                    }
                    break;
                case Direction.Vertical:
                    int y = (Line == -1) ? 0 : Line;
                    if (Column == -1) return;
                    Color colors = Point.GetColor(Column, y);
                    if (colors == Color.Red) tableLayoutPanelArray[y, Column].BackgroundImage = Properties.Resources.REDBOURD;
                    else if (colors == Color.Blue) tableLayoutPanelArray[y, Column].BackgroundImage = Properties.Resources.BLUEBOURD;
                    else if (colors == Color.Green) tableLayoutPanelArray[y, Column].BackgroundImage = Properties.Resources.GREENBOURD;
                    else if (colors == Color.Yellow) tableLayoutPanelArray[y, Column].BackgroundImage = Properties.Resources.YELLOWBOURD;
                    else if (colors == Color.Aquamarine) tableLayoutPanelArray[y, Column].BackgroundImage = Properties.Resources.CENTERBOURD;
                    else tableLayoutPanelArray[y, Column].BackgroundImage = Properties.Resources.WHITE;
                    ++y;
                    for (; y < 15; ++y)
                    {
                        Color brush = Point.MiddleColour(Color.DarkGray, Point.GetColor(Column, y));
                        tableLayoutPanelArray[y, Column].BackColor = brush;
                        tableLayoutPanelArray[y, Column].BackgroundImage = null;
                    }
                    break;
                case Direction.None:
                    break;
            }
        }
        private void Pas()
        {
            DeleteWord();
            RefillLitters(player);
            if (player == Player.First)
                SetPlayer(Player.Second);
            else if (player == Player.Second)
                SetPlayer(Player.First);
        }
        private void StartFieldFulling()
        {

            for (int y = 0; y < 15; ++y)
                for (int x = 0; x < 15; ++x)
                {
                    if (Point.IsBlue(x, y))
                    {
                        tableLayoutPanelArray[y, x].BackgroundImage = null;
                        tableLayoutPanelArray[y, x].BackColor = Color.Blue;
                    }
                    else if (Point.IsCenter(x, y))
                    {
                        tableLayoutPanelArray[y, x].BackgroundImage = null;
                        tableLayoutPanelArray[y, x].BackColor = Color.Aquamarine;
                    }
                    else if (Point.IsGreen(x, y))
                    {
                        tableLayoutPanelArray[y, x].BackgroundImage = null;
                        tableLayoutPanelArray[y, x].BackColor = Color.Green;
                    }
                    else if (Point.IsRed(x, y))
                    {
                        tableLayoutPanelArray[y, x].BackgroundImage = null;
                        tableLayoutPanelArray[y, x].BackColor = Color.Red;
                    }
                    else if (Point.IsYellow(x, y))
                    {
                        tableLayoutPanelArray[y, x].BackgroundImage = null;
                        tableLayoutPanelArray[y, x].BackColor = Color.Yellow;
                    }
                    else
                    {
                        tableLayoutPanelArray[y, x].BackgroundImage = Properties.Resources.Безымянный;
                        tableLayoutPanelArray[y, x].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
        }
        private void PushLitter(char litter)
        {
            if (Line == 7 && Column == 7) Data.CenterInterconnected = true;
            if (Line == -1 || Column == -1 || direction == Direction.None || player == Player.None) return;
            while (litterArray[Line, Column] != '\0' && 
                ((Line < 14 &&  direction == Direction.Vertical) 
                || (direction == Direction.Horizontal && Column < 14)))
            {
                Data.interconnectedWithAnotherWord = true;
                word += litterArray[Line, Column];
                wordCost += Data.litterCost[litterArray[Line, Column]];
                if (direction == Direction.Horizontal) Column++;
                else Line++;
            }
            word += litter;
            TMPlitterArray[Line, Column] = litter;
            TMPLabelArray[Line, Column].Text = Convert.ToString(litter);
            if (Point.GetColor(Line, Column) == Color.Green) wordCost += 2 * Data.litterCost[litter];
            else if (Point.GetColor(Line, Column) == Color.Yellow) wordCost += 3 * Data.litterCost[litter];
            else wordCost += Data.litterCost[litter];

            if (Point.GetColor(Line, Column) == Color.Red) wordMult *= 3;
            else if (Point.GetColor(Line, Column) == Color.Blue) wordMult *= 2;

            if (direction == Direction.Horizontal) { if (Column < 14) Column++; }
            else if (Line < 14)Line++;
            while (litterArray[Line, Column] != '\0' &&
                ((Line < 14 && direction == Direction.Vertical)
                || (direction == Direction.Horizontal && Column < 14)))
            {
                Data.interconnectedWithAnotherWord = true;
                word += litterArray[Line, Column];
                if (direction == Direction.Horizontal) Column++; 
                else Line++;
            }
            ResetFieldMarking();
        }


        private void DeleteWord()
        {
            ActivateButtons(player);
            word = "";
            wordCost = 0;
            wordMult = 1;
            Line = -1;
            Column = -1;
            Array.Copy(LabelArray, TMPLabelArray, LabelArray.Length);
            Array.Copy(litterArray, TMPlitterArray, litterArray.Length);
            TMPaviableLittersFirstPlayer = new List<char>(aviableLittersFirstPlayer);
            TMPaviableLittersSecondPlayer = new List<char>(aviableLittersSecondPlayer);
            for (int y = 0; y < 15; ++y)
                for (int x = 0; x < 15; ++x)
                    LabelArray[y, x].Text = Convert.ToString(litterArray[y, x]);

            StartFieldFulling();
            resetLabels();
        }
        private void resetLabels()
        {
            for (int i = 0; i < 15; ++i)
                for (int j = 0; j < 15; ++j)
                    LabelArray[i, j].Text = Convert.ToString(litterArray[i, j]);
        }

        public void SetWord()
        {
            if (Data.isFirstWord && !Data.CenterInterconnected)
            {
                MessageBox.Show("Первое слово должно проходить через центр");
                DeleteWord();
                return;
            }

            bool interconnected = Data.isFirstWord || Data.interconnectedWithAnotherWord;
            if (Data.PossibleWords.Contains(word) && interconnected)
            {
                aviableLittersFirstPlayer = TMPaviableLittersFirstPlayer;
                aviableLittersSecondPlayer = TMPaviableLittersSecondPlayer;
                Array.Copy(TMPlitterArray, litterArray, TMPlitterArray.Length);
                Array.Copy(TMPLabelArray, LabelArray, TMPLabelArray.Length);
                Data.isFirstWord = false;
                if (player == Player.First)
                {
                    label3.Text = Convert.ToString(int.Parse(label3.Text) + wordCost * wordMult);
                    SetPlayer(Player.Second);
                }
                else if (player == Player.Second)
                {
                    label4.Text = Convert.ToString(int.Parse(label4.Text) + wordCost * wordMult);
                    SetPlayer(Player.First);
                }
            }
            else
            {
                int countOfAsterisks = 0;
                if (!interconnected)
                    countOfAsterisks = -2;
                foreach (char litter in word)
                    if (litter == '*')
                        ++countOfAsterisks;

                if (countOfAsterisks == 1)
                {
                    bool containsMask = false;
                    char Litter = ' ';
                    for (char newLitter = 'a'; newLitter <= 'я'; newLitter++)
                    {
                        if (Data.PossibleWords.Contains(word.Replace('*', newLitter)))
                        {
                            containsMask = true;
                            Litter = newLitter;
                            break;
                        }
                    }
                    if (containsMask)
                    {
                        aviableLittersFirstPlayer = TMPaviableLittersFirstPlayer;
                        aviableLittersSecondPlayer = TMPaviableLittersSecondPlayer;
                        for (int x = 0; x < 15; ++x)
                            for (int y = 0; y < 15; ++y)
                                if (TMPlitterArray[x, y] == '*')
                                    TMPlitterArray[x, y] = Litter;
                        Array.Copy(TMPlitterArray, litterArray, TMPlitterArray.Length);
                        Array.Copy(TMPLabelArray, LabelArray, TMPLabelArray.Length);
                        StartFieldFulling();
                        resetLabels();
                        if (player == Player.First)
                        {
                            label3.Text = Convert.ToString(int.Parse(label3.Text) + wordCost * wordMult);
                            SetPlayer(Player.Second);
                        }
                        else if (player == Player.Second)
                        {
                            label4.Text = Convert.ToString(int.Parse(label4.Text) + wordCost * wordMult);
                            SetPlayer(Player.First);
                        }
                        return;
                    }
                    else
                    { countOfAsterisks = -1; }
             
                }
                if (countOfAsterisks > 1)
                    MessageBox.Show("Нельзя использовать две звездочки");
                if (countOfAsterisks <= 0)
                {
                    if (countOfAsterisks == 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("Засчитать??", "Нет такого слова: " + word, MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            aviableLittersFirstPlayer = TMPaviableLittersFirstPlayer;
                            aviableLittersSecondPlayer = TMPaviableLittersSecondPlayer;
                            Array.Copy(TMPlitterArray, litterArray, litterArray.Length);
                            Array.Copy(TMPLabelArray, LabelArray, LabelArray.Length);
                            if (player == Player.First)
                            {
                                label3.Text = Convert.ToString(int.Parse(label3.Text) + wordCost * wordMult);
                                SetPlayer(Player.Second);
                            }
                            else if (player == Player.Second)
                            {
                                label4.Text = Convert.ToString(int.Parse(label4.Text) + wordCost * wordMult);
                                SetPlayer(Player.First);
                            }
                            return;
                        }
                    }
                    else if (countOfAsterisks == -1) MessageBox.Show("Нет такого слова");
                    else if (countOfAsterisks == -2) MessageBox.Show("Слово должно пересекать другое слово");
                }
                resetLabels();
                StartFieldFulling();
                direction = Direction.None;
                Line = -1;
                Column = -1;
                if(player == Player.First)
                     ActivateButtons(Player.First);
                if (player == Player.Second)
                    ActivateButtons(Player.Second);
            }
        }

        private void ButtonChoose(int value, Direction direction)
        {
            int x = Column, y = Line;
            DeleteWord();
            Column = x;
            Line = y;


            if (player == Player.None) return;
            if (direction == Direction.Horizontal)
            {
                if (Line == -1)
                {
                    Line = value;
                    if (this.direction == Direction.None)
                        this.direction = Direction.Horizontal;
                }
                else if (Line == value)
                {
                    Line = -1;
                    if (this.direction == Direction.Horizontal)
                    {
                        this.direction = Direction.None;
                        Column = -1;
                    }
                }
                else
                {
                    Line = value;
                    if (this.direction == Direction.None)
                        this.direction = Direction.Horizontal;
                }
            }
            else if (direction == Direction.Vertical)
            {
                if (Column == -1)
                {
                    Column = value;
                    
                    if (this.direction == Direction.None)
                        this.direction = Direction.Vertical;
                }
                else if (Column == value)
                {
                    Column = -1;

                    if (this.direction == Direction.Vertical)
                    {
                        this.direction = Direction.None;
                        Line = -1;
                    }
                }
                else
                {
                    Column = value;
                    if (this.direction == Direction.None)
                        this.direction = Direction.Vertical;
                }
            }
            ResetFieldMarking();
        }

        private void makeAutoStep()
        {
            string maxWord = "";
            string s = "";
            bool wordIsSetted = false;
                if (Data.isFirstWord)
                {
                    s = findWord();
                    if (s.Length == 0)
                    {
                        Pas();
                        return;
                    }
                    Line = 7;
                    Column = 7 - s.Length / 2;
                    direction = Direction.Horizontal;
                    foreach (var litter in s)
                        PushLitter(litter);
                    Line = -1;
                    Column = -1;
                    direction = Direction.None;
                    SetWord();
                foreach (var item in s)
                {
                        if (player == Player.First)
                            aviableLittersFirstPlayer.Remove(item);
                        else
                            aviableLittersSecondPlayer.Remove(item);
                }
                    Data.PossibleWords.Remove(s);
            }
                else
                {
                    for (int y = 0; y < 15; ++y)
                        for (int x = 0; x < 15; ++x)
                            if (litterArray[y, x] != '\0')
                            {
                                int maxCost = 0;
                            
                                //horizontal Direction
                                {
                                    string mask = Convert.ToString(litterArray[y, x]);
                                    int left = leftDistance(y,x);
                                    int right = rightDistance(y,x);

                                if (left == 0 && right == 0) goto Vertical;
                                    for (int i = 1; i < left; ++i)
                                        mask = ' ' + mask;
                                    for (int i = 1; i < right; ++i)
                                        mask += ' ';
                                    s = findWord(mask);
                                if (costOfWord(s) > maxCost)
                                {
                                    wordIsSetted = TMPprint(y, x, s, Direction.Horizontal);
                                    maxWord = s;
                                }
                                }
                                Vertical:
                            //vertical Direction
                            {
                                    string mask =Convert.ToString(litterArray[y, x]);
                                    int up = upDistance(y, x);
                                    int down = downDistance(y, x);
                                    if (up == 0 && down == 0) continue;
                                    for (int i = 0; i < up; ++i)
                                        mask = ' ' + mask;
                                    for (int i = 0; i < down; ++i)
                                        mask += ' ';
                                    s = findWord(mask);
                                if (s.Length == 0)
                                    continue;
                                if (costOfWord(s) > maxCost)
                                {
                                    wordIsSetted =  TMPprint(y, x, s, Direction.Vertical);
                                    maxWord = s;
                                }
                                }
                            }
                Data.interconnectedWithAnotherWord = true;
                if (maxWord == "" || wordIsSetted == false)
                {
                    Pas();
                }

                else
                {
                    word = maxWord;
                    foreach (var item in maxWord)
                    {
                            if (player == Player.First)
                                aviableLittersFirstPlayer.Remove(item);
                            else
                                aviableLittersSecondPlayer.Remove(item);
                    }  
                    SetWord();
                    Data.PossibleWords.Remove(maxWord);
                }
                }
        }
        private bool TMPprint(int y, int x, string word, Direction dir)
        {
            DeleteWord();
            if (dir == Direction.None)
            {
                Exception e = new Exception("NONE PRINTS IN TMPPrint");
                throw e;
            }
            bool b = false;
            for (int i = 0; i < word.Length; ++i)
            {
                if (dir == Direction.Horizontal)
                    b = tryPrint(y, x - i, word, dir);
                else 
                    b = tryPrint(y - i, x, word, dir);
                if (b)
                {
                    if (dir == Direction.Vertical)
                    {
                        y = y - i;
                        direction = Direction.Vertical;
                        foreach (var item in word)
                        {
                            Column = x;
                            Line = y++;
                            if (litterArray[Line, Column] == '\0')
                                PushLitter(item);
                        }
                    }
                    else
                    {
                        x = x - i;
                        direction = Direction.Vertical;
                        foreach (var item in word)
                        {
                            Column = x++;
                            Line = y;
                            if (litterArray[Line, Column] == '\0')
                                PushLitter(item);
                        }
                    }
                    break;
                }
                else {
                    string s = "WTF";
                }
            }
            string w;
            if (b == false)
                w = "WTF";
            return b;
        }
        private bool tryPrint(int y, int x, string word, Direction dir)
        {
            bool answer = true;
            if (dir == Direction.Horizontal)
            {
                try
                {
                    foreach (var item in word)
                    {
                        if (litterArray[y, x] != item && litterArray[y, x] != '\0')
                        {
                            answer = false;
                            break;
                        }
                        x++;
                    }
                }
                catch { answer = false; }
            }
            else if (dir == Direction.Vertical)
            {
                try
                {
                    foreach (var item in word)
                    {
                        if (litterArray[y, x] != item && litterArray[y, x] != '\0')
                        {
                            answer = false;
                            break;
                        }
                        y++;
                    }
                }
                catch { answer = false; }
            }
            return answer;
        }

        private int leftDistance(int y, int x)
        {
            int answer = 0;
            while (x > 0 &&  litterArray[y, x - 1] == 0)
            {
                ++answer;
                --x;
            }
            return answer;
        }
        private int rightDistance(int y, int x)
        {
            int answer = 0;
            while (x < 14 && litterArray[y, x+1] == 0)
            {
                ++answer;
                ++x;
            }
            return answer;
        }
        private int upDistance(int y, int x)
        {
            int answer = 0;
            while (y > 0 && litterArray[y - 1, x] == 0)
            {
                ++answer;
                --y;
            }
            return answer;
        }
        private int downDistance(int y, int x)
        {
            int answer = 0;
            while (y < 14 && litterArray[y + 1, x] == 0)
            {
                ++answer;
                ++y;
            }
            return answer;
        }


        private Dictionary<char, int> GetNowLitters()
        {
            if (player == Player.None)
            {
                Exception e = new Exception("NOONE getNowLitters");
                throw e;
            }
            Dictionary<char, int> result = new Dictionary<char, int>();
            for (char i = 'а'; i <= 'я'; ++i)
                result.Add(i,0);
            result.Add('*',0);
            if (player == Player.First)
                foreach (var item in aviableLittersFirstPlayer)
                        result[item]++;
            else if(player == Player.Second)
                foreach (var item in aviableLittersSecondPlayer)
                        result[item]++;
            return result;
        }

        private string findWord(string mask = "        ")
        {
            List<string> possibleWords = countWords(mask);
            return wordWithMaxCost(possibleWords);
        }

        private bool goodWord(string word, string mask)
        {
            bool good = (mask.Length == 0) ? true : false;
            string innerMask = mask.Trim();
            for (int move = 0; move < word.Length - innerMask.Length; ++move)
            {
                good = true;
                for (int i =0; i < innerMask.Length;++i)
                {
                    if (innerMask[i] == ' ') continue;
                    if (innerMask[i] != word[i + move] && innerMask[i] != '*')
                    {
                        good = false;
                        break;
                    }
                }
                if (good)
                {
                    int leftCounter = 0;
                    for (int i = 0; i < mask.Length; ++i)
                        if (mask[i] == ' ') leftCounter++;
                        else break;
                    int rightCounter = 0;
                    for (int i = mask.Length - 1; i >= 0; --i)
                        if (mask[i] == ' ') rightCounter++;
                        else break;

                    if (move <= leftCounter && word.Length - innerMask.Length - move <= rightCounter)
                        good = true;
                    else
                        good = false;
                }
            }
            return good;
        }
        public List<string> countWords(string mask)
        {
            List<string> answer = new List<string>();
            Dictionary<char, int> alphabet = GetNowLitters();
            Dictionary<char, int> tmpalphabet;
            Random rand = new Random();

            foreach (var word in Data.PossibleWords)
            {
                if (!goodWord(word, mask)) continue;
                
                bool done = true;
                tmpalphabet = new Dictionary<char, int>(alphabet);
                foreach (var symbol in word)
                    if (tmpalphabet.ContainsKey(symbol))
                    {
                        if (tmpalphabet[symbol] < 1)
                        {
                            if (tmpalphabet['*'] < 1)
                            {
                                done = false;
                                break;
                            }
                            else
                                --tmpalphabet['*'];
                        }
                        else
                            --tmpalphabet[symbol];
                    }
                    else
                    {
                        if (mask.Contains(symbol))
                        {
                            mask.Remove(mask.IndexOf(symbol), 1);
                        }
                        else
                        {
                            done = false;
                            break;
                        }
                    } 
                  if (done)
                      answer.Add(word); 
                    
            }
            return answer;
        }

        private string wordWithMaxCost(List<string> words)
        {
            int max = 0;
            string answer = "";
            foreach (var item in words)
            {
                if (costOfWord(item) > max)
                    answer = item;
            }
            return answer;
        }

        private static int costOfWord(string word)
        {
            int sum = 0;
            foreach (var item in word)
            {
                foreach (var symbol in Data.litterCost)
                {
                    if (symbol.Key == item)
                    {
                        sum += symbol.Value;
                        break;
                    }
                }
            }
            return sum;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            ButtonChoose(0, Direction.Vertical);
        }
        private void button24_Click(object sender, EventArgs e)
        {
            ButtonChoose(1, Direction.Vertical);
        }
        private void button25_Click(object sender, EventArgs e)
        {
            ButtonChoose(2, Direction.Vertical);
        }
        private void button26_Click(object sender, EventArgs e)
        {
            ButtonChoose(3, Direction.Vertical);
        }
        private void button27_Click(object sender, EventArgs e)
        {
            ButtonChoose(4, Direction.Vertical);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            ButtonChoose(5, Direction.Vertical);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            ButtonChoose(6, Direction.Vertical);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            ButtonChoose(7, Direction.Vertical);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            ButtonChoose(8, Direction.Vertical);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            ButtonChoose(9, Direction.Vertical);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            ButtonChoose(10, Direction.Vertical);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            ButtonChoose(11, Direction.Vertical);
        }

        private void button35_Click(object sender, EventArgs e)
        {
            ButtonChoose(12, Direction.Vertical);
        }

        private void button36_Click(object sender, EventArgs e)
        {
            ButtonChoose(13, Direction.Vertical);
        }

        private void button37_Click(object sender, EventArgs e)
        {
            ButtonChoose(14, Direction.Vertical);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ButtonChoose(0, Direction.Horizontal);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ButtonChoose(1, Direction.Horizontal);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ButtonChoose(2, Direction.Horizontal);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ButtonChoose(3, Direction.Horizontal);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ButtonChoose(4, Direction.Horizontal);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ButtonChoose(5, Direction.Horizontal);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ButtonChoose(6, Direction.Horizontal);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ButtonChoose(7, Direction.Horizontal);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ButtonChoose(8, Direction.Horizontal);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ButtonChoose(9, Direction.Horizontal);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            ButtonChoose(10, Direction.Horizontal);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            ButtonChoose(11, Direction.Horizontal);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            ButtonChoose(12, Direction.Horizontal);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            ButtonChoose(13, Direction.Horizontal);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            ButtonChoose(14, Direction.Horizontal);
        }
        private void toolStripTextBox3_Click(object sender, EventArgs e)
        {
            Pas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Line == -1 || Column == -1 || direction == Direction.None || player == Player.None) return;
            if ((Line == 14 || Column == 14) && TMPlitterArray[Line, Column] != '\0') return;
            PushLitter(button1.Text[0]);
            TMPaviableLittersFirstPlayer.Remove(button1.Text[0]);
            button1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Line == -1 || Column == -1 || direction == Direction.None || player == Player.None) return;
            if ((Line == 14 || Column == 14) && TMPlitterArray[Line, Column] != '\0') return;
            PushLitter(button2.Text[0]);
            TMPaviableLittersFirstPlayer.Remove(button2.Text[0]);
            button2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Line == -1 || Column == -1 || direction == Direction.None || player == Player.None) return;
            if ((Line == 14 || Column == 14) && TMPlitterArray[Line, Column] != '\0') return;
            PushLitter(button3.Text[0]);
            TMPaviableLittersFirstPlayer.Remove(button3.Text[0]);
            button3.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Line == -1 || Column == -1 || direction == Direction.None || player == Player.None) return;
            if ((Line == 14 || Column == 14) && TMPlitterArray[Line, Column] != '\0') return;
            PushLitter(button4.Text[0]);
            TMPaviableLittersFirstPlayer.Remove(button4.Text[0]);
            button4.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Line == -1 || Column == -1 || direction == Direction.None || player == Player.None) return;
            if ((Line == 14 || Column == 14) && TMPlitterArray[Line, Column] != '\0') return;
            PushLitter(button5.Text[0]);
            TMPaviableLittersFirstPlayer.Remove(button5.Text[0]);
            button5.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Line == -1 || Column == -1 || direction == Direction.None || player == Player.None) return;
            if ((Line == 14 || Column == 14) && TMPlitterArray[Line, Column] != '\0') return;
            PushLitter(button6.Text[0]);
            TMPaviableLittersFirstPlayer.Remove(button6.Text[0]);
            button6.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Line == -1 || Column == -1 || direction == Direction.None || player == Player.None) return;
            if ((Line == 14 || Column == 14) && TMPlitterArray[Line, Column] != '\0') return;
            PushLitter(button7.Text[0]);
            TMPaviableLittersFirstPlayer.Remove(button7.Text[0]);
            button7.Visible = false;
        }

        private void button38_Click(object sender, EventArgs e)
        {
            DeleteWord();
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
            SetWord();
        }

        private void автоХодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteWord();
            if (player != Player.None)
                timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            makeAutoStep();
        }
    }

    enum Player
    { First, Second, None };
    enum Direction
    { Horizontal, Vertical, None };

    struct Point
    {
        private int x;
        public int X { get { return x; } set { if (value >= 0 && value <= 14) x = value; } }
        private int y;
        public int Y { get { return y; } set { if (value >= 0 && value <= 14) y = value; } }

        public Point(int n_x, int n_y)
        {
            y = x = 0;
            X = n_x;
            Y = n_y;
        }
        public static bool IsRed(int x, int y)
        { return Data.RedPoints.Contains(new Point(x, y)); }
        public static bool IsGreen(int x, int y)
        { return Data.GreenPoints.Contains(new Point(x, y)); }
        public static bool IsYellow(int x, int y)
        { return Data.YellowPoints.Contains(new Point(x, y)); }
        public static bool IsBlue(int x, int y)
        { return Data.BluePoints.Contains(new Point(x, y)); }
        public static bool IsCenter(int x, int y)
        { return (x == 7 && y == 7); }

        public static Color GetColor(int x, int y)
        {
            if (IsGreen(x, y)) return Color.Green;
            else if (IsRed(x, y)) return Color.Red;
            else if (IsBlue(x, y)) return Color.Blue;
            else if (IsYellow(x, y)) return Color.Yellow;
            else if (IsCenter(x, y)) return Color.Aquamarine;
            else return Color.White;
        }
        public static Color MiddleColour(Color a, Color b)
        {
            return Color.FromArgb(255, (a.R + b.R)/2, (a.G + b.G)/2, (a.B + b.B)/2);
        }

        //public static int PointMultipluer(int x, int y)
        //{

        //}

    };
}
