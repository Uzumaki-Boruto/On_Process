using System;
using System.Linq;
using System.Runtime.InteropServices;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using Color = System.Drawing.Color;
using SharpDX;

namespace UBStreaming
{
    class Program
    {
        private static float lastclick;
        private static readonly Random r = new Random();

        private static Menu Menu;

        private static AIHeroClient player
        {
            get { return Player.Instance; }
        }

        private static bool Pre;
        private static bool Stream
        {
            get { return (Menu["Menu"].Cast<KeyBind>().CurrentValue && Menu["Chat"].Cast<KeyBind>().CurrentValue) || CompleteTime < Game.Time - 7f; }
        }
        private static float CompleteTime;
        private static int Random
        {
            get { return Menu["Random"].Cast<Slider>().CurrentValue; }
        }

        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnLoadComplete;
        }

        static void OnLoadComplete(EventArgs args)
        {
            Orbwalker.OnPreAttack += Orbwalker_OnPreAttack;
            Orbwalker.OnPostAttack += AfterAttack;
            Player.OnIssueOrder += OnIssueOrder;
            Drawing.OnDraw += Drawing_OnDraw;
            Game.OnUpdate += GameOnUpdate;
            CompleteTime = Game.Time;

            Menu = MainMenu.AddMenu("UB Stream", "UBStream");
            Menu.AddLabel("Make by Uzumaki Boruto");
            Menu.Add("Random", new Slider("Random Delay per click 0.{0} sec", 1, 0, 5));
            Menu.AddLabel("Note: Press Shift won't show menu if Both true");
            Menu.Add("Menu", new KeyBind("Show menu key", true, KeyBind.BindTypes.PressToggle, '.'));
            Menu.Add("Chat", new KeyBind("Please Don't Change this key", false, KeyBind.BindTypes.HoldActive, 16));
        }

        private static void Drawing_OnDraw(EventArgs args)
        {
            if (Pre)
            {
                Drawing.DrawCircle(player.Position, player.GetAutoAttackRange() - 50f, Color.AliceBlue);
            }
        }

        private static void GameOnUpdate(EventArgs args)
        {
            if (Stream)
            {
                Hacks.DisableDrawings = true;
                Hacks.RenderWatermark = false;
            }
            if (!Stream)
            {
                Hacks.DisableDrawings = false;
                Hacks.RenderWatermark = true;
            }
        }
        private static void Orbwalker_OnPreAttack(AttackableUnit target, Orbwalker.PreAttackArgs args)
        {
            if (target != null && !target.IsDead)
            {
                Pre = true;
            }
        }
        private static void AfterAttack(AttackableUnit target, EventArgs args)
        {
            Pre = false;
        }
        private static void ShowClick(Vector3 position, ClickType type)
        {            
            Hud.ShowClick(type, position);
        }

        private static void OnIssueOrder(Obj_AI_Base sender, PlayerIssueOrderEventArgs args)
        {
            if (sender.IsMe &&
                (args.Order == GameObjectOrder.MoveTo || args.Order == GameObjectOrder.AttackUnit ||
                 args.Order == GameObjectOrder.AttackTo) &&
                lastclick + r.NextFloat(Random / 10, Random / 5) < Game.Time)
            {
                var clickpos = args.TargetPosition;
                if (args.Order == GameObjectOrder.AttackUnit || args.Order == GameObjectOrder.AttackTo)
                {
                    ShowClick(clickpos, ClickType.Attack);
                }
                else
                {
                    ShowClick(clickpos, ClickType.Move);
                }

                lastclick = Game.Time;
            }
        }
    }
}
