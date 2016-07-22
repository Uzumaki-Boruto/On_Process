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
            get { return Menu["Menu"].Cast<KeyBind>().CurrentValue && Menu["Chat"].Cast<KeyBind>().CurrentValue; }
        }

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

            Menu = MainMenu.AddMenu("UB Stream", "UBStream");
            Menu.Add("Random", new Slider("Random Modifier", 100, 0, 1000));
            Menu.AddLabel("Note: Press Shift won't show menu if Both true");
            Menu.Add("Menu", new KeyBind("Show menu key", false, KeyBind.BindTypes.PressToggle, '.'));
            Menu.Add("Chat", new KeyBind("Please Don't Change this key", false, KeyBind.BindTypes.HoldActive, 16));
        }

        static void Drawing_OnDraw(EventArgs args)
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
            if (target != null)
            {
                Pre = true;
            }
        }
        private static void ShowClick(Vector3 position, ClickType type)
        {            
            Hud.ShowClick(type, position);
        }

        private static void AfterAttack(AttackableUnit target, EventArgs args)
        {
            var t = target as AIHeroClient;
            if (t != null)
            {
                ShowClick(t.Position, ClickType.Attack);
            }
            Pre = false;
        }

        private static void OnIssueOrder(Obj_AI_Base sender, PlayerIssueOrderEventArgs args)
        {
            if (sender.IsMe &&
                (args.Order == GameObjectOrder.MoveTo || args.Order == GameObjectOrder.AttackUnit ||
                 args.Order == GameObjectOrder.AttackTo) &&
                lastclick + r.NextFloat(0.1f, 0.1f + 0.1f) < Game.Time)
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
