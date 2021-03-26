﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Korean_Flashcards
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodPage : ContentPage
    {
        Dictionary<string, KoreanWord> wordDict = new Dictionary<string, KoreanWord>();
        static Random rnd = new Random();
        int i = 0;
        public FoodPage()
        {
            InitializeComponent();
            wordDict.Add("Apple", new KoreanWord("사과", "sagwa"));
            wordDict.Add("Banana", new KoreanWord("바나나", "banana"));
            wordDict.Add("Potato", new KoreanWord("감자", "gamja"));
            wordDict.Add("Cabbage", new KoreanWord("양배추", "yangbaechu"));
            wordDict.Add("Mango", new KoreanWord("망고", "mang-go"));
            cardWord.Text = "Swipe LEFT for English, RIGHT for Korean" + "\n\n" + "and UP for a new card!";


        }

        void OnSwiped(object sender, SwipedEventArgs e)
        {
            var currentWord = wordDict.ElementAt(i);

            switch (e.Direction)
            {

                case SwipeDirection.Left:
                    cardWord.Text = currentWord.Key;
                    break;
                case SwipeDirection.Right:
                    cardWord.Text = currentWord.Value.getKoreanWord() + "\n" + currentWord.Value.getEnglishSound();
                    break;
                case SwipeDirection.Up:
                    i++;
                    if (i >= wordDict.Count)
                    {
                        i = 0;
                    }
                    currentWord = wordDict.ElementAt(i);
                    cardFrame.BackgroundColor = Color.FromRgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
                    cardWord.Text = currentWord.Key;
                    break;
                case SwipeDirection.Down:
                    cardWord.Text = "Down";
                    break;
            }
        }
        public class KoreanWord
        {
            string koreanWord;
            string englishSound;
            public KoreanWord(string koreanWord, string pronunciation)
            {
                this.koreanWord = koreanWord;
                englishSound = pronunciation;
            }

            public String getKoreanWord()
            {
                return koreanWord;
            }
            public String getEnglishSound()
            {
                return englishSound;
            }
        }
    }

}