using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTP.Common
{
    public class expression
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        public expression()
        {

            dict.Add("/微笑", 1);
            dict.Add("/撇嘴", 2);
            dict.Add("/色", 3);
            dict.Add("/发呆", 4);
            dict.Add("/得意", 5);
            dict.Add("/流泪", 6);
            dict.Add("/害羞", 7);
            dict.Add("/闭嘴", 8);
            dict.Add("/睡", 9);
            dict.Add("/大哭", 10);
            dict.Add("/尴尬", 11);
            dict.Add("/发怒", 12);
            dict.Add("/调皮", 13);
            dict.Add("/呲牙", 14);
            dict.Add("/惊讶", 15);
            dict.Add("/难过", 16);
            dict.Add("/酷", 17);
            dict.Add("/冷汗", 18);
            dict.Add("/抓狂", 19);
            dict.Add("/吐", 20);
            dict.Add("/偷笑", 21);
            dict.Add("/可爱", 22);
            dict.Add("/白眼", 23);
            dict.Add("/傲慢", 24);
            dict.Add("/饥饿", 25);
            dict.Add("/困", 26);
            dict.Add("/惊恐", 27);
            dict.Add("/流汗", 28);
            dict.Add("/憨笑", 29);
            dict.Add("/大兵", 30);
            dict.Add("/奋斗", 31);
            dict.Add("/咒骂", 32);
            dict.Add("/疑问", 33);
            dict.Add("/嘘...", 34);
            dict.Add("/晕", 35);
            dict.Add("/折磨", 36);
            dict.Add("/衰", 37);
            dict.Add("/骷髅", 38);
            dict.Add("/敲打", 39);
            dict.Add("/再见", 40);
            dict.Add("/擦汗", 41);
            dict.Add("/抠鼻", 42);
            dict.Add("/鼓掌", 43);
            dict.Add("/糗大了", 44);
            dict.Add("/坏笑", 45);
            dict.Add("/左哼哼", 46);
            dict.Add("/右哼哼", 47);
            dict.Add("/哈欠", 48);
            dict.Add("/鄙视", 49);
            dict.Add("/委屈", 50);
            dict.Add("/快哭了", 51);
            dict.Add("/阴险", 52);
            dict.Add("/亲亲", 53);
            dict.Add("/吓", 54);
            dict.Add("/可怜", 55);
            dict.Add("/菜刀", 56);
            dict.Add("/西瓜", 57);
            dict.Add("/啤酒", 58);
            dict.Add("/篮球", 59);
            dict.Add("/乒乓", 60);
            dict.Add("/咖啡", 61);
            dict.Add("/饭", 62);
            dict.Add("/猪头", 63);
            dict.Add("/玫瑰", 64);
            dict.Add("/凋谢", 65);
            dict.Add("/示爱", 66);
            dict.Add("/爱心", 67);
            dict.Add("/心碎", 68);
            dict.Add("/蛋糕", 69);
            dict.Add("/闪电", 70);
            dict.Add("/炸弹", 71);
            dict.Add("/刀", 72);
            dict.Add("/足球", 73);
            dict.Add("/瓢虫", 74);
            dict.Add("/便便", 75);
            dict.Add("/月亮", 76);
            dict.Add("/太阳", 77);
            dict.Add("/礼物", 78);
            dict.Add("/拥抱", 79);
            dict.Add("/强", 80);
            dict.Add("/弱", 81);
            dict.Add("/握手", 82);
            dict.Add("/胜利", 83);
            dict.Add("/报拳", 84);
            dict.Add("/勾引", 85);
            dict.Add("/拳头", 86);
            dict.Add("/差劲", 87);
            dict.Add("/爱你", 88);
            dict.Add("/NO", 89);
            dict.Add("/OK", 90);
        }
        public string convertExp(string inText)
        {
            foreach (KeyValuePair<string, Int32> kvp in dict)
            {
                inText = inText.Replace(kvp.Key, "<img src='/Images/t/" + kvp.Value.ToString() + ".gif' title='" + kvp.Key + "' />");
            }
            return inText;
        }
    }
}
