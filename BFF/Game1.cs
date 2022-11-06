using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.Collisions;
using System.Collections.Generic;
using MonoGame.Extended;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Content;
using MonoGame.Extended.ViewportAdapters;
using FireRescue;
using System;
using System.IO;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;



namespace Prototype02
{
    public class Game1 :Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        bool isMenu;
        bool isTutorial;
        bool isGameplay1;
        bool isGameplay2;
        bool isscore;
        bool invi;

        SpriteFont Fontforgame;

        List<string> m_listTexts; 
        List<Vector2> m_listVec2;

        List<string> menu_listTexts;
        List<Vector2> menu_listVec2;

        List<string> score_listTexts;
        List<Vector2> score_listVec2;



        const int MapWidth = 28800 ;
        const int MapHeight = 19200;

        public static OrthographicCamera _camera;
        public static Vector2 _cameraPosition;
        public static Vector2 _bgPosition;
        
        TiledMap _TutorialtileMap;
        TiledMap _Gameplay1tilemap;
        TiledMap _Gameplay2tilemap;

        TiledMapRenderer _prototypetiledMapRenderer;
        TiledMapRenderer _Gameplay1tiledMapRenderer;
        TiledMapRenderer _Gameplay2tiledMapRenderer;
        Texture2D ItemExt;
        Texture2D ItemAxe;
        Texture2D invisible;
        Texture2D Press_F;
        Texture2D MapMenu;
        private const float Rotation = 0;
        private const float Scale = 1.0f;
        private const float Depth = 0.5f;
        bool animate_stop = false;

        private readonly List<IEntity> _entities = new List<IEntity>();
        private readonly List<IEntity> _entities1 = new List<IEntity>();
        private readonly List<IEntity> _entities2 = new List<IEntity>();

        public readonly CollisionComponent _collisionComponent;
        public readonly CollisionComponent _collisionComponent1;
        public readonly CollisionComponent _collisionComponent2;

        Song break_door;
        Song button_pressed;
        Song door_opening;
        Song fire;
        Song fire_extinguisher;
        Song hit_fire;
        Song hit_stone;
        Song level_win;
        Song obj_falling;
        Song pick_up_item;
        Song pick_up_npc;
        Song you_died;
        Song jump;
        Song Menubgm;
        

        TiledMapObjectLayer _PlatformTiledObj;
        TiledMapObjectLayer _PlatformtrapObject;
        TiledMapObjectLayer _FireObj;
        TiledMapObjectLayer _Fire2Obj;
        TiledMapObjectLayer _Fire3Obj;
        TiledMapObjectLayer _Fire4Obj;
        TiledMapObjectLayer _NpcObj;
        TiledMapObjectLayer _Npc2Obj;
        TiledMapObjectLayer _GoalObj;
        TiledMapObjectLayer _Goal2Obj;
        TiledMapObjectLayer _BrokenObj;
        TiledMapObjectLayer _Broken2Obj;
        TiledMapObjectLayer _Broken3Obj;
        TiledMapObjectLayer _Broken4Obj;
        TiledMapObjectLayer _aex_item;
        TiledMapObjectLayer _Door_obj;
        TiledMapObjectLayer _extinguisherwithfire3;
        TiledMapObjectLayer _extinguisherwithfire4;
        TiledMapObjectLayer _itemuse;
        TiledMapObjectLayer _itemuse2;
        TiledMapObjectLayer _player;

        


        bool istrap;
        int itemextinguisher1;
        int itemextinguisher2;
        int itemaxe;
        bool rescue;
        bool ext;
        bool axe;
        bool countstart;
        public int rescuenum;
        int _Ext;
        int _HP;
        int _thisScore;
        bool death;

        int frame;
        float totalElapsed;
        float timePerFrame;
        int framePerSec;
        Texture2D Idle;


        Vector2 temp_player_pos;
        Vector2 temp_map_pos=new Vector2(0,0);
        
        double time_counter = 1000;
        float countdown = 1f;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            //_graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
            //_collisionComponentMenu = new CollisionComponent(new RectangleF(0, 0, MapWidth, MapHeight));
            _collisionComponent = new CollisionComponent(new RectangleF(0, 0, MapWidth, MapHeight));
            _collisionComponent1= new CollisionComponent(new RectangleF(0, 0, MapWidth, MapHeight));
            _collisionComponent2 = new CollisionComponent(new RectangleF(0, 0, MapWidth, MapHeight));

           

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            

            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 2400  ;
            _graphics.PreferredBackBufferHeight = 1200 ;
            _graphics.ApplyChanges();

             m_listTexts = new List<string>();
             m_listVec2 = new List<Vector2>(); 
            string filepath = Path.Combine(@"Content\text.txt");
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read); 
            StreamReader sr = new StreamReader(fs); while (!sr.EndOfStream) 
            { 
                string tmpStr = sr.ReadLine(); 
                m_listTexts.Add(tmpStr); 
            }
            sr.Close();
            string filepath2 = Path.Combine(@"Content\textvector.txt"); 
            FileStream fs2 = new FileStream(filepath2, FileMode.Open, FileAccess.Read); 
            StreamReader sr2 = new StreamReader(fs2); 
            string 
            tmpStr2 = sr2.ReadLine(); 
            int num01 = Int32.Parse(tmpStr2); 
            tmpStr2 = sr2.ReadLine(); 
            int num02 = Int32.Parse(tmpStr2); 
            tmpStr2 = sr2.ReadLine(); 
            int num03 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num04 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num05 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num06 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num07 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num08 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num09 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num10 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num11 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num12 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num13 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num14 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num15 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num16 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num17 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num18 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num19 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num20 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num21 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num22 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num23 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num24 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num25 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num26 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num27 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num28 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num29 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num30 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num31 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num32 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num33 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num34 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num35 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num36 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num37 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num38 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num39 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num40 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num41 = Int32.Parse(tmpStr2);
            tmpStr2 = sr2.ReadLine();
            int num42 = Int32.Parse(tmpStr2);

            m_listVec2.Add(new Vector2(num01, num02)); 
            m_listVec2.Add(new Vector2(num03, num04));
            m_listVec2.Add(new Vector2(num05, num06));
            m_listVec2.Add(new Vector2(num07, num08));
            m_listVec2.Add(new Vector2(num09, num10));
            m_listVec2.Add(new Vector2(num11, num12));
            m_listVec2.Add(new Vector2(num13, num14));
            m_listVec2.Add(new Vector2(num15, num16));
            m_listVec2.Add(new Vector2(num17, num18));
            m_listVec2.Add(new Vector2(num19, num20));
            m_listVec2.Add(new Vector2(num21, num22));
            m_listVec2.Add(new Vector2(num23, num24));
            m_listVec2.Add(new Vector2(num25, num26));
            m_listVec2.Add(new Vector2(num27, num28));
            m_listVec2.Add(new Vector2(num29, num30));
            m_listVec2.Add(new Vector2(num31, num32));
            m_listVec2.Add(new Vector2(num33, num34));
            m_listVec2.Add(new Vector2(num35, num36));
            m_listVec2.Add(new Vector2(num37, num38));
            m_listVec2.Add(new Vector2(num39, num40));
            m_listVec2.Add(new Vector2(num41, num42));
            sr2.Close();


            menu_listTexts = new List<string>();
            menu_listVec2 = new List<Vector2>();
            string filepathmenu = Path.Combine(@"Content\textMenu.txt");
            FileStream fsmenu = new FileStream(filepathmenu, FileMode.Open, FileAccess.Read);
            StreamReader srmenu = new StreamReader(fsmenu); while (!srmenu.EndOfStream)
            {
                string tmpStrmenu = srmenu.ReadLine();
                menu_listTexts.Add(tmpStrmenu);
            }
            srmenu.Close();
            string filepathmenu2 = Path.Combine(@"Content\textMenuvec.txt");
            FileStream fsmenu2 = new FileStream(filepathmenu2, FileMode.Open, FileAccess.Read);
            StreamReader srmenu2 = new StreamReader(fsmenu2);
            string
            tmpStrmenu2 = srmenu2.ReadLine();
            int menunum01 = Int32.Parse(tmpStrmenu2);
            tmpStrmenu2 = srmenu2.ReadLine();
            int menunum02 = Int32.Parse(tmpStrmenu2);
            

            menu_listVec2.Add(new Vector2(menunum01, menunum02));

            srmenu2.Close();

            score_listTexts = new List<string>();
            score_listVec2 = new List<Vector2>();
            string filepathscore = Path.Combine(@"Content\textScor.txt");
            FileStream fsscore = new FileStream(filepathscore, FileMode.Open, FileAccess.Read);
            StreamReader srscore = new StreamReader(fsscore); while (!srscore.EndOfStream)
            {
                string tmpStrscore = srscore.ReadLine();
                score_listTexts.Add(tmpStrscore);
            }
            srscore.Close();
            string filepathscore2 = Path.Combine(@"Content\textScorvec.txt");
            FileStream fsscore2 = new FileStream(filepathscore2, FileMode.Open, FileAccess.Read);
            StreamReader srscore2 = new StreamReader(fsscore2);
            string
            tmpStrscore2 = srscore2.ReadLine();
            int scorenum01 = Int32.Parse(tmpStrscore2);
            tmpStrscore2 = srscore2.ReadLine();
            int scorenum02 = Int32.Parse(tmpStrscore2);
            tmpStrscore2 = srscore2.ReadLine();
            int scorenum03 = Int32.Parse(tmpStrscore2);
            tmpStrscore2 = srscore2.ReadLine();
            int scorenum04 = Int32.Parse(tmpStrscore2);
            tmpStrscore2 = srscore2.ReadLine();
            int scorenum05 = Int32.Parse(tmpStrscore2);
            tmpStrscore2 = srscore2.ReadLine();
            int scorenum06 = Int32.Parse(tmpStrscore2);
            tmpStrscore2 = srscore2.ReadLine();
            int scorenum07 = Int32.Parse(tmpStrscore2);
            tmpStrscore2 = srscore2.ReadLine();
            int scorenum08 = Int32.Parse(tmpStrscore2);


            score_listVec2.Add(new Vector2(scorenum01, scorenum02));
            score_listVec2.Add(new Vector2(scorenum03, scorenum04));
            score_listVec2.Add(new Vector2(scorenum05, scorenum06));
            score_listVec2.Add(new Vector2(scorenum07, scorenum08));


            srscore2.Close();

            var Viewportadapter = new BoxingViewportAdapter(Window, GraphicsDevice, MapWidth/12, MapHeight/12 );
            _camera = new OrthographicCamera(Viewportadapter);
            //rescue = false;
            _bgPosition = new Vector2(0, 0);
            //Hello World


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Fontforgame = Content.Load<SpriteFont>("Textforgame");

            
            _TutorialtileMap = Content.Load<TiledMap>("Map_Tutorial");
            _Gameplay1tilemap = Content.Load<TiledMap>("Map_Gameplay1");
            _Gameplay2tilemap = Content.Load<TiledMap>("Map_Gameplay2");
            ItemExt = Content.Load<Texture2D>("Resources/Ext_icon");
            ItemAxe = Content.Load<Texture2D>("Resources/Axe_icon");
            MapMenu = Content.Load<Texture2D>("Resources/menu");
            invisible = Content.Load<Texture2D>("Resources/immortal icon");

            Press_F= Content.Load<Texture2D>("Resources/Button_F(240)");

            this.break_door = Content.Load<Song>("Resources/break_door");
            this.button_pressed= Content.Load<Song>("Resources/button_pressed");
            this.door_opening= Content.Load<Song>("Resources/door_opening");
            this.fire= Content.Load<Song>("Resources/fire-1");
            this.fire_extinguisher= Content.Load<Song>("Resources/fire_ext");
            this.hit_fire= Content.Load<Song>("Resources/hit_fire");
            this.hit_stone= Content.Load<Song>("Resources/hit_stone");
            this.level_win= Content.Load<Song>("Resources/level_win");
            this.obj_falling= Content.Load<Song>("Resources/obj_falling");
            this.pick_up_item= Content.Load<Song>("Resources/pick_up_item");
            this.pick_up_npc= Content.Load<Song>("Resources/pick_up_npc");
            this.you_died= Content.Load<Song>("Resources/you_died");
            this.jump = Content.Load<Song>("Resources/jump");
            this.Menubgm = Content.Load<Song>("Resources/MenuSong");

            MediaPlayer.Volume = 0.6f;
            MediaPlayer.Play(Menubgm);
            MediaPlayer.IsRepeating = true; MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;

            _prototypetiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _TutorialtileMap);
            _Gameplay1tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _Gameplay1tilemap);
            _Gameplay2tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _Gameplay2tilemap);
            
            isMenu =true;
            isTutorial =false;
            isGameplay1 =false;
            isGameplay2 = false;
            isscore = false;
            death = false;
            invi = false;

            istrap = false;
            _thisScore = 0;
            ext = false;
            countstart = false;


          

            LoadMenu();
            LoadTutorial();
            LoadGamePlay1();
            LoadGamePlay2();
            Loadscore();


            // TODO: use this.Content to load your game content here
        }
        void MediaPlayer_MediaStateChanged(object sender,System.EventArgs e)
        {
            MediaPlayer.Volume = 1f;
            MediaPlayer.Play(fire);

        }
        public void LoadMenu()

        {
            Idle = Content.Load<Texture2D>("Sprite Sheet Char");
            framePerSec = 5;
            timePerFrame = (float)1 / framePerSec;
            frame = 0;
            totalElapsed = 0;
            //MediaPlayer.Play(Menubgm);
            //MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
        }

        public void LoadTutorial()
        {
            foreach (TiledMapObjectLayer layer in _TutorialtileMap.ObjectLayers)
            {
                if (layer.Name == "_PlatformTiledObj")
                {
                    _PlatformTiledObj = layer;
                }
                if (layer.Name == "_PlatformtrapObject")
                {
                    _PlatformtrapObject = layer;
                }
                if (layer.Name == "Fire_Object")
                {
                    _FireObj = layer;
                }
                if (layer.Name == "Fire_Object2")
                {
                    _Fire2Obj = layer;
                }
                if (layer.Name == "Fire_Object3")
                {
                    _Fire3Obj = layer;
                }
                if (layer.Name == "Fire_Object3")
                {
                    _Fire3Obj = layer;
                }
                if (layer.Name == "Fire_Object4")
                {
                    _Fire4Obj = layer;
                }
                if (layer.Name == "Npc_Object")
                {
                    _NpcObj = layer;
                }
                if (layer.Name == "Npc_Object2")
                {
                    _Npc2Obj = layer;
                }
                if (layer.Name == "Broken_Object")
                {
                    _BrokenObj = layer;
                }
                if (layer.Name == "Broken_Object2")
                {
                    _Broken2Obj = layer;
                }
                if (layer.Name == "Broken_Object3")
                {
                    _Broken3Obj = layer;
                }
                if (layer.Name == "Broken_Object4")
                {
                    _Broken4Obj = layer;
                }
                if (layer.Name == "Goal_Object2")
                {
                    _Goal2Obj = layer;
                }
                if (layer.Name == "axe_item")
                {
                    _aex_item = layer;
                }
                if (layer.Name == "extinguisherwithfire3")
                {
                    _extinguisherwithfire3 = layer;
                }
                if (layer.Name == "extinguisherwithfire4")
                {
                    _extinguisherwithfire4 = layer;
                }
                if (layer.Name == "Itemuse")
                {
                    _itemuse = layer;
                }
                if (layer.Name == "Door_Object")
                {
                    _Door_obj = layer;
                }
                if (layer.Name == "Itemuse2")
                {
                    _itemuse2 = layer;
                }
               
            }

                foreach (TiledMapObject Obj in _PlatformTiledObj.Objects)
                {
                    Point2 position = new Point2(Obj.Position.X, Obj.Position.Y);

                    _entities.Add(new PlatformEntity(this, new RectangleF(position, Obj.Size)));

                }

                foreach (TiledMapObject Obj in _PlatformtrapObject.Objects)
                {
                    Point2 position = new Point2(Obj.Position.X, Obj.Position.Y);

                    _entities.Add(new PlatformEntityTrap(this, new RectangleF(position, Obj.Size)));

                }
            foreach (TiledMapObject Obj in _itemuse.Objects)
            {
                Point2 position = new Point2(Obj.Position.X, Obj.Position.Y);

                _entities.Add(new Itemuse(this, new RectangleF(position, Obj.Size)));

            }
            foreach (TiledMapObject Obj in _itemuse2.Objects)
            {
                Point2 position = new Point2(Obj.Position.X, Obj.Position.Y);

                _entities.Add(new Itemuse2(this, new RectangleF(position, Obj.Size)));

            }
            SpriteSheet fireSheet = Content.Load<SpriteSheet>("Resources/fire Sprite sheet.sf", new JsonContentLoader());
                foreach (TiledMapObject Obj in _FireObj.Objects)
                {
                    Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 2);
                    _entities.Add(new FireEntity(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(fireSheet)));
                }
                foreach (TiledMapObject Obj in _Fire2Obj.Objects)
                {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 2);
                _entities.Add(new FireEntity2(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(fireSheet)));
                }
                SpriteSheet fireSheet3 = Content.Load<SpriteSheet>("Resources/fire Sprite sheet fire 3.sf", new JsonContentLoader());
                foreach (TiledMapObject Obj in _Fire3Obj.Objects)
                {
                    Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 4);
                    _entities.Add(new FireEntity3(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(fireSheet3)));
                    
                }
                SpriteSheet fireSheet4 = Content.Load<SpriteSheet>("Resources/fire pillar Sprite sheet.sf", new JsonContentLoader());
                foreach (TiledMapObject Obj in _Fire4Obj.Objects)
                {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width );

                    _entities.Add(new FireEntity4(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(fireSheet4)));
                }

                SpriteSheet npcSheet = Content.Load<SpriteSheet>("Resources/NPC sprite sheet.sf", new JsonContentLoader());
                foreach (TiledMapObject Obj in _NpcObj.Objects)
                {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 2);
                _entities.Add(new NpcEntity(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(npcSheet)));
                }
                foreach (TiledMapObject Obj in _Npc2Obj.Objects)
                {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 2);
                _entities.Add(new NpcEntity2(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(npcSheet)));
                }

                SpriteSheet goalSheet = Content.Load<SpriteSheet>("Resources/goal sprite sheet.sf", new JsonContentLoader());
                
                foreach (TiledMapObject Obj in _Goal2Obj.Objects)
                {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 2);
                _entities.Add(new GoalEntity2(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(goalSheet)));
                }

            List<BrokenEntity> tempBrokens = new List<BrokenEntity>();
            List<BrokenEntity2> tempBrokens2 = new List<BrokenEntity2>();
            List<BrokenEntity3> tempBrokens3 = new List<BrokenEntity3>();
            List<BrokenEntity4> tempBrokens4 = new List<BrokenEntity4>();

            SpriteSheet Broken = Content.Load<SpriteSheet>("Resources/broken sheet.sf", new JsonContentLoader());
            foreach (TiledMapObject Obj in _BrokenObj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Height / 2);

                BrokenEntity tBroken = new BrokenEntity(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(Broken));
                tempBrokens.Add(tBroken);

                _entities.Add(tBroken);
            }

            foreach (TiledMapObject Obj in _Broken2Obj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Height / 2);

                BrokenEntity tBroken = new BrokenEntity(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(Broken));
                tempBrokens.Add(tBroken);

                _entities.Add(tBroken);
            }

            foreach (TiledMapObject Obj in _Broken3Obj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Height / 2);

                BrokenEntity tBroken = new BrokenEntity(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(Broken));
                tempBrokens.Add(tBroken);

                _entities.Add(tBroken);
            }

            foreach (TiledMapObject Obj in _Broken4Obj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Height / 2);

                BrokenEntity tBroken = new BrokenEntity(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(Broken));
                tempBrokens.Add(tBroken);

                _entities.Add(tBroken);
            }

            int i = 0;
            foreach (TiledMapObject Obj in _PlatformtrapObject.Objects)
            {
                Point2 position = new Point2(Obj.Position.X, Obj.Position.Y);

                _entities.Add(new PlatformEntityTrap(this, new RectangleF(position, Obj.Size), tempBrokens[i]));
                /*_entities.Add(new PlatformEntityTrap(this, new RectangleF(position, Obj.Size), tempBrokens2[i]));
                  _entities.Add(new PlatformEntityTrap(this, new RectangleF(position, Obj.Size), tempBrokens3[i]));
                  _entities.Add(new PlatformEntityTrap(this, new RectangleF(position, Obj.Size), tempBrokens4[i]));*/
                i++;
            }

            SpriteSheet Item = Content.Load<SpriteSheet>("Resources/Item Sheet.sf", new JsonContentLoader());
                foreach (TiledMapObject Obj in _aex_item.Objects)
                {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 2);

                _entities.Add(new aex_item(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(Item)));

                }
                foreach (TiledMapObject Obj in _extinguisherwithfire3.Objects)
                {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 2);

                _entities.Add(new extinguisherwithfire3(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(Item)));

                }
                   foreach (TiledMapObject Obj in _extinguisherwithfire4.Objects)
                {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 2);

                _entities.Add(new extinguisherwithfire4(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(Item)));

                }
               SpriteSheet Door = Content.Load<SpriteSheet>("Resources/door_sprite_sheet.sf", new JsonContentLoader());
                foreach (TiledMapObject Obj in _Door_obj.Objects)
                {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 2);

                _entities.Add(new DoorEntity(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(Door)));

                }

                 
                //_entities.Add(new Iconext(this, new RectangleF(new Vector2(0, 2400), new Size(120, 120), ItemExt)));

                 SpriteSheet O2sheet = Content.Load<SpriteSheet>("Resources/Oxygen sheet.sf", new JsonContentLoader());
                 _entities.Add(new O2bar(this, new RectangleF(new Vector2(0, 2400), new Size2(720, 240)), new AnimatedSprite(O2sheet)));

                 SpriteSheet icon = Content.Load<SpriteSheet>("Resources/health status sheet.sf", new JsonContentLoader());
                 _entities.Add(new icon(this, new RectangleF(new Vector2(0, 2400), new Size2(120, 120)), new AnimatedSprite(icon)));
            //TextContentLoader Text = Content.Load<TextContentLoader>("Textforgame.spritefont"),new JsonContentLoader());
            //_entities.Add(new )

            SpriteSheet playerSheet = Content.Load<SpriteSheet>("Resources/Sprite Sheet Char.sf", new JsonContentLoader());
               
                _entities.Add(new PlayerEntity(this, new RectangleF(new Vector2(0, 2400), new Size2(240, 240)), new AnimatedSprite(playerSheet)));

                foreach (IEntity entity in _entities)
                {
                    _collisionComponent.Insert(entity);
                }

            
        }

        public void LoadGamePlay1()
        {
            foreach (TiledMapObjectLayer layer in _Gameplay1tilemap.ObjectLayers)
            {
                if (layer.Name == "_PlatformTiledObj")
                {
                    _PlatformTiledObj = layer;
                }
                if (layer.Name == "_PlatformtrapObject")
                {
                    _PlatformtrapObject = layer;
                }
                if (layer.Name == "Fire_Object")
                {
                    _FireObj = layer;
                }
                if (layer.Name == "Fire_Object2")
                {
                    _Fire2Obj = layer;
                }
                if (layer.Name == "Fire_Object3")
                {
                    _Fire3Obj = layer;
                }
                if (layer.Name == "Fire_Object3")
                {
                    _Fire3Obj = layer;
                }
                if (layer.Name == "Fire_Object4")
                {
                    _Fire4Obj = layer;
                }
                if (layer.Name == "Npc_Object")
                {
                    _NpcObj = layer;
                }
                if (layer.Name == "Npc_Object2")
                {
                    _Npc2Obj = layer;
                }
                if (layer.Name == "Broken_Object")
                {
                    _BrokenObj = layer;
                }
                if (layer.Name == "Broken_Object2")
                {
                    _Broken2Obj = layer;
                }
                if (layer.Name == "Broken_Object3")
                {
                    _Broken3Obj = layer;
                }
                if (layer.Name == "Broken_Object4")
                {
                    _Broken4Obj = layer;
                }
                if (layer.Name == "Goal_Object")
                {
                    _GoalObj = layer;
                }
                if (layer.Name == "axe_item")
                {
                    _aex_item = layer;
                }
                if (layer.Name == "Door_Object1")
                {
                    _Door_obj = layer;
                }
                if (layer.Name == "extinguisherwithfire3")
                {
                    _extinguisherwithfire3 = layer;
                }
                if (layer.Name == "extinguisherwithfire4")
                {
                    _extinguisherwithfire4 = layer;
                }
                if (layer.Name == "Itemuse")
                {
                    _itemuse = layer;
                }
                if (layer.Name == "Itemuse2")
                {
                    _itemuse2 = layer;
                }
                
            }

                foreach (TiledMapObject Obj in _PlatformTiledObj.Objects)
                {
                    Point2 position = new Point2(Obj.Position.X, Obj.Position.Y);

                    _entities1.Add(new PlatformEntity(this, new RectangleF(position, Obj.Size)));

                }

                foreach (TiledMapObject Obj in _itemuse.Objects)
                {
                    Point2 position = new Point2(Obj.Position.X, Obj.Position.Y);

                    _entities1.Add(new Itemuse(this, new RectangleF(position, Obj.Size)));

                }
                foreach (TiledMapObject Obj in _itemuse2.Objects)
                {
                    Point2 position = new Point2(Obj.Position.X, Obj.Position.Y);

                    _entities1.Add(new Itemuse2(this, new RectangleF(position, Obj.Size)));

                }
                SpriteSheet fireSheet = Content.Load<SpriteSheet>("Resources/fire Sprite sheet.sf", new JsonContentLoader());
                foreach (TiledMapObject Obj in _FireObj.Objects)
                {
                    Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 2);
                    _entities1.Add(new FireEntity(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(fireSheet)));
                }
                foreach (TiledMapObject Obj in _Fire2Obj.Objects)
                {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 2);
                _entities1.Add(new FireEntity2(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(fireSheet)));
                }
                SpriteSheet fireSheet3 = Content.Load<SpriteSheet>("Resources/fire Sprite sheet fire 3.sf", new JsonContentLoader());
                foreach (TiledMapObject Obj in _Fire3Obj.Objects)
                {
                    Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 4);
                    _entities1.Add(new FireEntity3(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(fireSheet3)));

                }
                SpriteSheet fireSheet4 = Content.Load<SpriteSheet>("Resources/fire pillar Sprite sheet.sf", new JsonContentLoader());
                foreach (TiledMapObject Obj in _Fire4Obj.Objects)
                {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width );
                _entities1.Add(new FireEntity4(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(fireSheet4)));
                }

                SpriteSheet npcSheet = Content.Load<SpriteSheet>("Resources/NPC sprite sheet.sf", new JsonContentLoader());
                foreach (TiledMapObject Obj in _NpcObj.Objects)
                {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 2);
                _entities1.Add(new NpcEntity(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(npcSheet)));
                }
                foreach (TiledMapObject Obj in _Npc2Obj.Objects)
                {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 2);
                _entities1.Add(new NpcEntity2(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(npcSheet)));
                }

                SpriteSheet goalSheet = Content.Load<SpriteSheet>("Resources/goal sprite sheet.sf", new JsonContentLoader());

                foreach (TiledMapObject Obj in _GoalObj.Objects)
                {
                    Point2 position = new Point2(Obj.Position.X + Obj.Size.Width/2, Obj.Position.Y + Obj.Size.Width/2);
                    _entities1.Add(new GoalEntity(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(goalSheet)));
                }





            List<BrokenEntity> tempBrokens = new List<BrokenEntity>();
            List<BrokenEntity2> tempBrokens2 = new List<BrokenEntity2>();
            List<BrokenEntity3> tempBrokens3 = new List<BrokenEntity3>();
            List<BrokenEntity4> tempBrokens4 = new List<BrokenEntity4>();

            SpriteSheet Broken = Content.Load<SpriteSheet>("Resources/broken sheet.sf", new JsonContentLoader());
            foreach (TiledMapObject Obj in _BrokenObj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Height / 2);

                BrokenEntity tBroken = new BrokenEntity(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(Broken));
                tempBrokens.Add(tBroken);

                _entities1.Add(tBroken);
            }

            foreach (TiledMapObject Obj in _Broken2Obj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Height / 2);

                BrokenEntity tBroken = new BrokenEntity(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(Broken));
                tempBrokens.Add(tBroken);

                _entities1.Add(tBroken);
            }

            foreach (TiledMapObject Obj in _Broken3Obj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Height / 2);

                BrokenEntity tBroken = new BrokenEntity(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(Broken));
                tempBrokens.Add(tBroken);

                _entities1.Add(tBroken);
            }

            foreach (TiledMapObject Obj in _Broken4Obj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Height / 2);

                BrokenEntity tBroken = new BrokenEntity(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(Broken));
                tempBrokens.Add(tBroken);

                _entities1.Add(tBroken);
            }

            int i = 0;
            foreach (TiledMapObject Obj in _PlatformtrapObject.Objects)
            {
                Point2 position = new Point2(Obj.Position.X, Obj.Position.Y);

                _entities1.Add(new PlatformEntityTrap(this, new RectangleF(position, Obj.Size), tempBrokens[i]));
              /*_entities1.Add(new PlatformEntityTrap(this, new RectangleF(position, Obj.Size), tempBrokens2[i]));
                _entities1.Add(new PlatformEntityTrap(this, new RectangleF(position, Obj.Size), tempBrokens3[i]));
                _entities1.Add(new PlatformEntityTrap(this, new RectangleF(position, Obj.Size), tempBrokens4[i]));*/
                i++;
            }



            SpriteSheet Item = Content.Load<SpriteSheet>("Resources/Item Sheet.sf", new JsonContentLoader());
                foreach (TiledMapObject Obj in _aex_item.Objects)
                {

                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 2);

                _entities1.Add(new aex_item(this, new CircleF(position, Obj.Size.Width/2), new AnimatedSprite(Item)));

                }
                foreach (TiledMapObject Obj in _extinguisherwithfire3.Objects)
                {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 2);

                _entities1.Add(new extinguisherwithfire3(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(Item)));

                }
                   foreach (TiledMapObject Obj in _extinguisherwithfire4.Objects)
                {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width/2, Obj.Position.Y + Obj.Size.Width/2);

                _entities1.Add(new extinguisherwithfire4(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(Item)));

                }
                SpriteSheet Door = Content.Load<SpriteSheet>("Resources/door_sprite_sheet.sf", new JsonContentLoader());
                foreach (TiledMapObject Obj in _Door_obj.Objects)
                {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 2);
                _entities1.Add(new DoorEntity(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(Door)));

                }

                SpriteSheet O2sheet = Content.Load<SpriteSheet>("Resources/Oxygen sheet.sf", new JsonContentLoader());
                _entities1.Add(new O2bar(this, new RectangleF(new Vector2(480, 3600), new Size2(720, 240)), new AnimatedSprite(O2sheet)));

                 SpriteSheet icon = Content.Load<SpriteSheet>("Resources/health status sheet.sf", new JsonContentLoader());
                 _entities1.Add(new icon(this, new RectangleF(new Vector2(0, 2400), new Size2(120, 120)), new AnimatedSprite(icon)));
        
            
            
                 SpriteSheet playerSheet = Content.Load<SpriteSheet>("Resources/Sprite Sheet Char.sf", new JsonContentLoader());

                _entities1.Add(new PlayerEntity(this, new RectangleF(new Vector2(480, 3360), new Size2(240, 240)), new AnimatedSprite(playerSheet)));

                foreach (IEntity entity in _entities1)
                {
                    _collisionComponent1.Insert(entity);
                }

            }
        
        public void LoadGamePlay2()
        {
            foreach (TiledMapObjectLayer layer in _Gameplay2tilemap.ObjectLayers)
            {
                if (layer.Name == "_PlatformTiledObj")
                {
                    _PlatformTiledObj = layer;
                }
                if (layer.Name == "_PlatformtrapObject")
                {
                    _PlatformtrapObject = layer;
                }
                if (layer.Name == "Fire_Object")
                {
                    _FireObj = layer;
                }
                if (layer.Name == "Fire_Object2")
                {
                    _Fire2Obj = layer;
                }
                if (layer.Name == "Fire_Object3")
                {
                    _Fire3Obj = layer;
                }
                if (layer.Name == "Fire_Object3")
                {
                    _Fire3Obj = layer;
                }
                if (layer.Name == "Fire_Object4")
                {
                    _Fire4Obj = layer;
                }
                if (layer.Name == "Npc_Object")
                {
                    _NpcObj = layer;
                }
                if (layer.Name == "Npc_Object2")
                {
                    _Npc2Obj = layer;
                }
                if (layer.Name == "Broken_Object2")
                {
                    _Broken2Obj = layer;
                }
                if (layer.Name == "Broken_Object3")
                {
                    _Broken3Obj = layer;
                }
                if (layer.Name == "Broken_Object4")
                {
                    _Broken4Obj = layer;
                }
                if (layer.Name == "Goal_Object")
                {
                    _GoalObj = layer;
                }
                if (layer.Name == "axe_item")
                {
                    _aex_item = layer;
                }
                if (layer.Name == "extinguisherwithfire3")
                {
                    _extinguisherwithfire3 = layer;
                }
                if (layer.Name == "extinguisherwithfire4")
                {
                    _extinguisherwithfire4 = layer;
                }
                if (layer.Name == "Door_Object")
                {
                    _Door_obj = layer;
                }
                if (layer.Name == "Itemuse")
                {
                    _itemuse = layer;
                }
                if (layer.Name == "Itemuse2")
                {
                    _itemuse2 = layer;
                }
            }

            foreach (TiledMapObject Obj in _PlatformTiledObj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X, Obj.Position.Y);

                _entities2.Add(new PlatformEntity(this, new RectangleF(position, Obj.Size)));

            }

            foreach (TiledMapObject Obj in _itemuse.Objects)
            {
                Point2 position = new Point2(Obj.Position.X, Obj.Position.Y);

                _entities2.Add(new Itemuse(this, new RectangleF(position, Obj.Size)));

            }
            foreach (TiledMapObject Obj in _itemuse2.Objects)
            {
                Point2 position = new Point2(Obj.Position.X, Obj.Position.Y);

                _entities2.Add(new Itemuse2(this, new RectangleF(position, Obj.Size)));

            }
            SpriteSheet fireSheet = Content.Load<SpriteSheet>("Resources/fire Sprite sheet.sf", new JsonContentLoader());
            foreach (TiledMapObject Obj in _FireObj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 2);
                _entities2.Add(new FireEntity(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(fireSheet)));
            }
            foreach (TiledMapObject Obj in _Fire2Obj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 2);
                _entities2.Add(new FireEntity2(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(fireSheet)));
            }
            SpriteSheet fireSheet3 = Content.Load<SpriteSheet>("Resources/fire Sprite sheet fire 3.sf", new JsonContentLoader());
            foreach (TiledMapObject Obj in _Fire3Obj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 4);
                _entities2.Add(new FireEntity3(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(fireSheet3)));

            }
            SpriteSheet fireSheet4 = Content.Load<SpriteSheet>("Resources/fire pillar Sprite sheet.sf", new JsonContentLoader());
            foreach (TiledMapObject Obj in _Fire4Obj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width);
                _entities2.Add(new FireEntity4(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(fireSheet4)));
            }

            SpriteSheet npcSheet = Content.Load<SpriteSheet>("Resources/NPC sprite sheet.sf", new JsonContentLoader());
            foreach (TiledMapObject Obj in _NpcObj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 2);
                _entities2.Add(new NpcEntity(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(npcSheet)));
            }
            foreach (TiledMapObject Obj in _Npc2Obj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 2);
                _entities2.Add(new NpcEntity2(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(npcSheet)));
            }

            SpriteSheet goalSheet = Content.Load<SpriteSheet>("Resources/goal sprite sheet.sf", new JsonContentLoader());

            foreach (TiledMapObject Obj in _GoalObj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 2);
                _entities2.Add(new GoalEntity(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(goalSheet)));
            }





            
            List<BrokenEntity2> tempBrokens2 = new List<BrokenEntity2>();

            SpriteSheet Broken = Content.Load<SpriteSheet>("Resources/broken sheet.sf", new JsonContentLoader());
            foreach (TiledMapObject Obj in _Broken2Obj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Height / 2);

                BrokenEntity2 tBroken = new BrokenEntity2(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(Broken));
                tempBrokens2.Add(tBroken);

                _entities2.Add(tBroken);
            }

            foreach (TiledMapObject Obj in _Broken3Obj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Height / 2);

                BrokenEntity2 tBroken = new BrokenEntity2(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(Broken));
                tempBrokens2.Add(tBroken);

                _entities2.Add(tBroken);
            }

            foreach (TiledMapObject Obj in _Broken4Obj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Height / 2);

                BrokenEntity2 tBroken = new BrokenEntity2(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(Broken));
                tempBrokens2.Add(tBroken);

                _entities2.Add(tBroken);
            }

            int i = 0;
            foreach (TiledMapObject Obj in _PlatformtrapObject.Objects)
            {
                Point2 position = new Point2(Obj.Position.X, Obj.Position.Y);

                
            _entities2.Add(new PlatformEntityTrap(this, new RectangleF(position, Obj.Size), tempBrokens2[i]));
                  
                i++;
            }


            SpriteSheet Item = Content.Load<SpriteSheet>("Resources/Item Sheet.sf", new JsonContentLoader());
            foreach (TiledMapObject Obj in _aex_item.Objects)
            {

                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 2);
                
                _entities2.Add(new aex_item(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(Item)));

            }
            foreach (TiledMapObject Obj in _extinguisherwithfire3.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 2);

                _entities2.Add(new extinguisherwithfire3(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(Item)));

            }
            foreach (TiledMapObject Obj in _extinguisherwithfire4.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 2);

                _entities2.Add(new extinguisherwithfire4(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(Item)));

            }
            SpriteSheet Door = Content.Load<SpriteSheet>("Resources/door_sprite_sheet.sf", new JsonContentLoader());
            foreach (TiledMapObject Obj in _Door_obj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 2);
                _entities2.Add(new DoorEntity(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(Door)));

            }

            SpriteSheet O2sheet = Content.Load<SpriteSheet>("Resources/Oxygen sheet.sf", new JsonContentLoader());
            _entities2.Add(new O2bar(this, new RectangleF(new Vector2(0, 2400), new Size2(720, 240)), new AnimatedSprite(O2sheet)));

            SpriteSheet icon = Content.Load<SpriteSheet>("Resources/health status sheet.sf", new JsonContentLoader());
            _entities2.Add(new icon(this, new RectangleF(new Vector2(0, 2400), new Size2(120, 120)), new AnimatedSprite(icon)));

            SpriteSheet playerSheet = Content.Load<SpriteSheet>("Resources/Sprite Sheet Char.sf", new JsonContentLoader());

            _entities2.Add(new PlayerEntity(this, new RectangleF(new Vector2(480, 9600), new Size2(240, 240)), new AnimatedSprite(playerSheet)));

            foreach (IEntity entity in _entities2)
            {
                _collisionComponent2.Insert(entity);
            }
        }
        public void Loadscore()
        {

        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
                
            if (countdown > 0 && countstart == true)
            {
                countdown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (countdown <= 0)
            {
                countdown = 0;
            }
            if ((Keyboard.GetState().IsKeyDown(Keys.W)) || (Keyboard.GetState().IsKeyDown(Keys.W))&& (Keyboard.GetState().IsKeyDown(Keys.A) ||  (Keyboard.GetState().IsKeyDown(Keys.W)) && (Keyboard.GetState().IsKeyDown(Keys.D))))
            {
                MediaPlayer.Volume = 0.1f;
                MediaPlayer.Play(jump);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.F) && ext)
            {
                MediaPlayer.Volume = 1f;
                MediaPlayer.Play(fire_extinguisher);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F) && axe)
            {
                MediaPlayer.Volume = 1f;
                MediaPlayer.Play(break_door);
            }
            if (death && HEALTH() == 0 || time_counter <= 0)
            {
                MediaPlayer.Volume = 1f;
                MediaPlayer.Play(you_died);
            }

 

            if (isMenu == true &&isTutorial==false&& isGameplay2 == false&&isGameplay1==false)
            {

                UpdateMenu();

                UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);

                /*foreach (IEntity entity in _entitiesmenu)
                {
                    if (entity is playermenuentity)
                    {

                    }
                    entity.Update(gameTime);
                }*/

                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    isMenu = false;
                    isTutorial = true;
                    isGameplay1 = false;
                    isGameplay2 = false;
                    isscore = false;
                    MediaPlayer.Play(fire);
                    MediaPlayer.IsRepeating = true; 
                    MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
                    rescuenum = 0;
                    time_counter = 60;

                }
                _camera.LookAt(_cameraPosition+temp_map_pos);
            }

            if (isTutorial == true&& isGameplay2 == false&&isGameplay1==false&& isMenu == false && isscore == false)
            {
                UpdateTutorial();  
                foreach (IEntity entity in _entities)
             {
                if (entity is PlatformEntity)
                {
                    
                }
                if (entity is PlatformEntityTrap)
                    {

                    }
                    if (entity is FireEntity)
                {
                    if (!((FireEntity)entity).IsExist())
                    {
                        //_collisionComponent.Remove(entity);
                        //Exit();
                    }
                }
                
                if (entity is FireEntity2)
                {
                    if (!((FireEntity2)entity).IsExist())
                    {
                        //_collisionComponent.Remove(entity);
                        //Exit();
                    }
                }
                if(entity is GoalEntity2)
                    {
                        if(((GoalEntity2)entity).IsRescue() && rescuenum >= 2)
                        {
                            isMenu = false;
                            isGameplay1 = true;
                            isTutorial = false;
                            isGameplay2 = false;
                            isscore = false;
                            rescuenum = 0;
                            time_counter = 180;
                              MediaPlayer.Play(fire);
                    MediaPlayer.IsRepeating = true; 
                    MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;

                        }
                    }

                    if (entity is Itemuse)
                    {
                        if (((Itemuse)entity).Item() && itemextinguisher1 >= 1)
                        {
                            ext = true;
                        }

                        if (((Itemuse)entity).Item() && itemextinguisher2 >= 1)
                        {
                            ext = true;
                        }
                        

                    }
                    if (entity is Itemuse2)
                    {
                        if (((Itemuse2)entity).Item() && itemaxe >= 1)
                        {
                            axe = true;
                        }
                   
                    }

                    if (entity is extinguisherwithfire3)
                    {
                        if (!((extinguisherwithfire3)entity).IsExist())
                        {
                            _collisionComponent.Remove(entity);
                            MediaPlayer.Play(pick_up_item);
                            _entities.Remove(entity);
                            itemextinguisher1 += 1;
                            _Ext += 1;
                            break;
                        }
                    }
                    if (entity is extinguisherwithfire4)
                    {
                        if (!((extinguisherwithfire4)entity).IsExist())
                        {
                            _collisionComponent.Remove(entity);
                            MediaPlayer.Play(pick_up_item);
                            _entities.Remove(entity);
                            itemextinguisher2 += 1;
                            _Ext += 1;
                            break;
                        }
                    }

                    if (entity is FireEntity3)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.F) && ext && itemextinguisher1 >= 1)
                        {
                            countstart = true;
                        }
                        if (countdown == 0 && itemextinguisher1 >= 1)
                        {
                            _collisionComponent.Remove(entity);
                            _entities.Remove(entity);
                            itemextinguisher1 -= 1;
                            countdown = 1f;
                            ext = false;
                            _Ext -= 1;
                            countstart = false;
                            break;
                        }
                    }

                    if (entity is FireEntity4)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.F) && ext && itemextinguisher2 >= 1)
                        {
                            countstart = true;
                        }
                        if (countdown == 0 && itemextinguisher2 >= 1)
                        {
                            itemextinguisher2 -= 1;
                            _collisionComponent.Remove(entity);
                            _entities.Remove(entity);
                            countdown = 1f;
                            ext = false;
                            _Ext -= 1;
                            countstart = false;
                            break;
                        }
                    }
                    if (entity is aex_item)
                    {
                        if (!((aex_item)entity).IsExist())
                        {
                            _collisionComponent.Remove(entity);
                            MediaPlayer.Play(pick_up_item);
                            _entities.Remove(entity);
                            itemaxe += 1;
                            break;
                        }
                    }
                    if (entity is DoorEntity)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.F) && axe && itemaxe >= 1)
                        {
                            countstart = true;
                        }
                        if (countdown == 0 && itemaxe >= 1)
                        {
                            itemaxe -= 1;
                            _collisionComponent.Remove(entity);
                            _entities.Remove(entity);
                            countdown = 1f;
                            axe = false;
                            countstart = false;
                            break;
                        }
                    }


                    if (entity is NpcEntity)
                    {
                        if (((NpcEntity)entity).IsRescue())
                        {
                            //_collisionComponent.Remove(entity);
                            MediaPlayer.Volume = 1f;
                            MediaPlayer.Play(pick_up_npc);
                            _entities.Remove(entity);
                            rescuenum += 1;
                            _thisScore += 100;
                            break;
                        }
                        /*if (((NpcEntity)entity).AllRescue())
                        {
                            rescue = true;
                        }*/
                    }
                    if (entity is NpcEntity2)
                    {
                        if (((NpcEntity2)entity).IsRescue())
                        {
                            //_collisionComponent.Remove(entity);
                            MediaPlayer.Volume = 1f;
                            MediaPlayer.Play(pick_up_npc);
                            _entities.Remove(entity);
                            rescuenum += 1;
                            _thisScore += 100;
                            break;
                        }
                        /*if (((NpcEntity)entity).AllRescue())
                        {
                            rescue = true;
                        }*/
                    }

                    if (entity is PlatformEntityTrap)
                    {
                        if (((PlatformEntityTrap)entity).ISHIT())
                        {
                            istrap = true;
                        }
                    }

                    if (entity is BrokenEntity)
                    {
                    if (!((BrokenEntity)entity).Past())
                    {
                        ((BrokenEntity)entity).Bounds.Position = ((BrokenEntity)entity).Oldpos;
                        
                    }
                        if (((BrokenEntity)entity).Trap() && !death && HEALTH() > 0)
                        {
                            MediaPlayer.Volume = 1f;
                            MediaPlayer.Play(hit_stone);
                        }
                    }
                    if (entity is BrokenEntity2)
                    {
                    if (!((BrokenEntity2)entity).Past())
                    {
                            ((BrokenEntity2)entity).Bounds.Position = ((BrokenEntity2)entity).Oldpos;

                    }
                        if (((BrokenEntity2)entity).Trap() && !death && HEALTH() > 0)
                        {
                            MediaPlayer.Volume = 1f;
                            MediaPlayer.Play(hit_stone);
                        }
                    }
                if (entity is BrokenEntity3)
                    {
                    if (!((BrokenEntity3)entity).Past())
                        {
                            ((BrokenEntity3)entity).Bounds.Position = ((BrokenEntity3)entity).Oldpos;

                        }
                    }
                if (entity is BrokenEntity4)
                    {
                    if (!((BrokenEntity4)entity).Past())
                        {
                            ((BrokenEntity4)entity).Bounds.Position = ((BrokenEntity4)entity).Oldpos;

                        }                   
                    }  


                    if (entity is PlayerEntity)
                {
                    float tempX = ((PlayerEntity)entity).Bounds.Position.X;
                    float tempY = ((PlayerEntity)entity).Bounds.Position.Y;
                    temp_player_pos = new Vector2(tempX, tempY);
                        _HP = (((PlayerEntity)entity).HEALTH());
                        if (((PlayerEntity)entity).IsHit())
                        {
                            istrap = false;
                        }
                        if (((PlayerEntity)entity).BURN())
                        {
                            MediaPlayer.Volume = 1f;
                            MediaPlayer.Play(hit_fire);
                        }
                        if (((PlayerEntity)entity).INVISIBLE())
                        {
                            invi = true;
                        }
                        if (!((PlayerEntity)entity).INVISIBLE())
                        {
                            invi = false;
                        }
                        if (((PlayerEntity)entity).DEATH())
                        {
                            death = true;
                        }
                        if (!((PlayerEntity)entity).DEATH())
                        {
                            death = false;
                        }
                        if (Keyboard.GetState().IsKeyDown(Keys.Enter) && death && time_counter <= 0)
                        {
                            time_counter = 36;

                        }
                        //((BrokenEntity)entity).Bounds.Position = ((BrokenEntity)entity).Oldpos;
                    }
                entity.Update(gameTime);
              }
                _camera.LookAt(temp_player_pos + _cameraPosition);

            }

            if (isGameplay1 == true &&isTutorial==false&& isGameplay2 == false&& isMenu == false && isscore == false)
            {
                UpdateGameplay1();
                foreach (IEntity entity in _entities1)
                {
                    if (entity is PlatformEntity)
                    {

                    }
                    if (entity is PlatformEntityTrap)
                    {
                        
                    }
                    if (entity is FireEntity)
                    {
                        if (!((FireEntity)entity).IsExist())
                        {
                            //_collisionComponent1.Remove(entity);
                            //Exit();
                        }
                    }

                    if (entity is FireEntity2)
                    {
                        if (!((FireEntity2)entity).IsExist())
                        {
                            //_collisionComponent1.Remove(entity);
                            //Exit();
                        }
                    }
                    if (entity is Itemuse)
                    {
                        if (((Itemuse)entity).Item() && itemextinguisher1 >= 1)
                        {
                            ext = true;
                        }

                        if (((Itemuse)entity).Item() && itemextinguisher2 >= 1)
                        {
                            ext = true;
                        }


                    }
                    if (entity is Itemuse2)
                    {
                        if (((Itemuse2)entity).Item() && itemaxe >= 1)
                        {
                            axe = true;
                        }

                    }
                    if (entity is GoalEntity)
                    {
                        if (((GoalEntity)entity).IsRescue() && rescuenum >= 4)
                        {
                            isMenu = false;
                            isGameplay1 = false;
                            isTutorial = false;
                            isGameplay2 = true;
                            isscore = false;
                            rescuenum = 0;
                            time_counter = 420;
                            MediaPlayer.Play(fire);
                            MediaPlayer.IsRepeating = true;
                            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
                        }
                    }


                    if (entity is extinguisherwithfire3)
                    {
                        if (!((extinguisherwithfire3)entity).IsExist())
                        {
                            _collisionComponent1.Remove(entity);
                            MediaPlayer.Play(pick_up_item);
                            _entities1.Remove(entity);
                            itemextinguisher1 += 1;
                            _Ext += 1;
                            break;
                        }
                    }
                    if (entity is extinguisherwithfire4)
                    {
                        if (!((extinguisherwithfire4)entity).IsExist())
                        {
                            _collisionComponent1.Remove(entity);
                            MediaPlayer.Play(pick_up_item);
                            _entities1.Remove(entity);
                            itemextinguisher2 += 1;
                            _Ext += 1;
                            break;
                        }
                    }

                    if (entity is FireEntity3)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.F) && ext && itemextinguisher1 >= 1)
                        {
                            countstart = true;
                        }
                        if (countdown == 0 && itemextinguisher1 >= 1)
                        {
                            _collisionComponent1.Remove(entity);
                            _entities1.Remove(entity);
                            itemextinguisher1 -= 1;
                            countdown = 1f;
                            ext = false;
                            _Ext -= 1;
                            countstart = false;
                            break;
                        }
                    }

                    if (entity is FireEntity4)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.F) && ext && itemextinguisher2 >= 1)
                        {
                            countstart = true;
                        }
                        if (countdown == 0 && itemextinguisher2 >= 1)
                        {
                            itemextinguisher2 -= 1;
                            _collisionComponent1.Remove(entity);
                            _entities1.Remove(entity);
                            countdown = 1f;
                            ext = false;
                            _Ext -= 1;
                            countstart = false;
                            break;
                        }
                    }
                    if (entity is Itemuse2)
                    {
                        if (((Itemuse2)entity).Item() && itemaxe >= 1)
                        {
                            axe = true;
                        }
                    }
                    if (entity is aex_item)
                    {
                        if (!((aex_item)entity).IsExist())
                        {
                            _collisionComponent1.Remove(entity);
                            MediaPlayer.Play(pick_up_item);
                            _entities1.Remove(entity);
                            itemaxe += 1;
                            break;
                        }
                    }
                    if (entity is DoorEntity)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.F) && axe && itemaxe >= 1)
                        {
                            countstart = true;
                        }
                        if (countdown == 0 && itemaxe >= 1)
                        {
                            itemaxe -= 1;
                            _collisionComponent1.Remove(entity);
                            _entities1.Remove(entity);
                            countdown = 1f;
                            axe = false;
                            countstart = false;
                            break;
                        }
                    }


                    if (entity is NpcEntity)
                    {
                        if (((NpcEntity)entity).IsRescue())
                        {
                            //_collisionComponent.Remove(entity);
                            _entities1.Remove(entity);
                            rescuenum += 1;
                            _thisScore += 100;
                            MediaPlayer.Volume = 1f;
                            MediaPlayer.Play(pick_up_npc);
                            break;
                        }
                        /*if (((NpcEntity)entity).AllRescue())
                        {
                            rescue = true;
                        }*/
                    }
                    if (entity is NpcEntity2)
                    {
                        if (((NpcEntity2)entity).IsRescue())
                        {
                            //_collisionComponent.Remove(entity);
                            _entities1.Remove(entity);
                            rescuenum += 1;
                            _thisScore += 100;
                            MediaPlayer.Volume = 1f;
                            MediaPlayer.Play(pick_up_npc);
                            break;
                        }
                        /*if (((NpcEntity)entity).AllRescue())
                        {
                            rescue = true;
                        }*/
                    }

                    if (entity is PlatformEntityTrap)
                    {
                        if (((PlatformEntityTrap)entity).ISHIT())
                        {
                            istrap = true;
                        }
                    }


                    if (entity is BrokenEntity)
                    {
                        if (!((BrokenEntity)entity).Past())
                        {
                            ((BrokenEntity)entity).Bounds.Position = ((BrokenEntity)entity).Oldpos;

                        }
                        if (((BrokenEntity)entity).Trap() && !death && HEALTH() > 0)
                        {
                            MediaPlayer.Volume = 1f;
                            MediaPlayer.Play(hit_stone);
                        }
                    }
                    if (entity is BrokenEntity2)
                    {
                        if (!((BrokenEntity2)entity).Past())
                        {
                            ((BrokenEntity2)entity).Bounds.Position = ((BrokenEntity2)entity).Oldpos;

                        }
                        if (((BrokenEntity2)entity).Trap() && !death && HEALTH() > 0)
                        {
                            MediaPlayer.Volume = 1f;
                            MediaPlayer.Play(hit_stone);
                        }
                    }

                    if (entity is BrokenEntity3)
                    {
                        if (!((BrokenEntity3)entity).Past())
                        {
                            ((BrokenEntity3)entity).Bounds.Position = ((BrokenEntity3)entity).Oldpos;

                        }
                    }
                    if (entity is BrokenEntity4)
                    {
                        if (!((BrokenEntity4)entity).Past())
                        {
                            ((BrokenEntity4)entity).Bounds.Position = ((BrokenEntity4)entity).Oldpos;

                        }
                    }


                    if (entity is PlayerEntity)
                    {
                        float tempX = ((PlayerEntity)entity).Bounds.Position.X;
                        float tempY = ((PlayerEntity)entity).Bounds.Position.Y;
                        temp_player_pos = new Vector2(tempX, tempY);
                        _HP = (((PlayerEntity)entity).HEALTH());
                        if (((PlayerEntity)entity).IsHit())
                        {
                            istrap = false;
                        }
                        if (((PlayerEntity)entity).BURN())
                        {
                            MediaPlayer.Volume = 1f;
                            MediaPlayer.Play(hit_fire);
                        }
                        if (((PlayerEntity)entity).INVISIBLE())
                        {
                            invi = true;
                        }
                        if (!((PlayerEntity)entity).INVISIBLE())
                        {
                            invi = false;
                        }
                        if (((PlayerEntity)entity).DEATH())
                        {
                            death = true;
                        }
                        if (!((PlayerEntity)entity).DEATH())
                        {
                            death = false;
                        }
                        if (Keyboard.GetState().IsKeyDown(Keys.Enter) && death && time_counter <= 0)
                        {
                            time_counter = 91;

                        }
                        //((BrokenEntity)entity).Bounds.Position = ((BrokenEntity)entity).Oldpos;


                    }
                    entity.Update(gameTime);
                }
                _camera.LookAt(temp_player_pos + _cameraPosition);

            }

            if (isGameplay2 == true && isTutorial == false && isGameplay1 == false&& isMenu == false&& isscore == false)
            {
                UpdateGameplay2();

                foreach (IEntity entity in _entities2)
                {
                    if (entity is PlatformEntity)
                    {

                    }
                    if (entity is PlatformEntityTrap)
                    {

                    }
                    if (entity is FireEntity)
                    {
                        if (!((FireEntity)entity).IsExist())
                        {
                            //_collisionComponent2.Remove(entity);
                            //Exit();
                        }
                    }

                    if (entity is FireEntity2)
                    {
                        if (!((FireEntity2)entity).IsExist())
                        {
                            //_collisionComponent2.Remove(entity);
                            //Exit();
                        }
                    }
                    if (entity is GoalEntity)
                    {
                        if (((GoalEntity)entity).IsRescue() && rescuenum >= 4)
                        {
                            isMenu = false;
                            isTutorial = false;
                            isGameplay1 = false;
                            isGameplay2 = false;
                            isscore = true;
                            rescuenum = 0;
                            time_counter = 60;
                            MediaPlayer.Volume = 1f;
                            MediaPlayer.Play(level_win);

                        }
                    }
                    if (entity is Itemuse)
                    {
                        if (((Itemuse)entity).Item() && itemextinguisher1 >= 1)
                        {
                            ext = true;
                        }

                        if (((Itemuse)entity).Item() && itemextinguisher2 >= 1)
                        {
                            ext = true;
                        }


                    }
                    if (entity is Itemuse2)
                    {
                        if (((Itemuse2)entity).Item() && itemaxe >= 1)
                        {
                            axe = true;
                        }

                    }


                    if (entity is extinguisherwithfire3)
                    {
                        if (!((extinguisherwithfire3)entity).IsExist())
                        {
                            _collisionComponent2.Remove(entity);
                            MediaPlayer.Play(pick_up_item);
                            _entities2.Remove(entity);
                            itemextinguisher1 += 1;
                            _Ext += 1;
                            break;
                        }
                    }
                    if (entity is extinguisherwithfire4)
                    {
                        if (!((extinguisherwithfire4)entity).IsExist())
                        {
                            _collisionComponent2.Remove(entity);
                            MediaPlayer.Play(pick_up_item);
                            _entities2.Remove(entity);
                            itemextinguisher2 += 1;
                            _Ext += 1;
                            break;
                        }
                    }

                    if (entity is FireEntity3)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.F) && ext && itemextinguisher1 >= 1)
                        {
                            countstart = true;
                        }
                        if (countdown == 0 && itemextinguisher1 >= 1)
                        {
                            _collisionComponent2.Remove(entity);
                            _entities2.Remove(entity);
                            itemextinguisher1 -= 1;
                            countdown = 1f;
                            ext = false;
                            _Ext -= 1;
                            countstart = false;
                            break;
                        }
                    }

                    if (entity is FireEntity4)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.F) && ext && itemextinguisher2 >= 1)
                        {
                            countstart = true;
                        }
                        if (countdown == 0 && itemextinguisher2 >= 1)
                        {
                            itemextinguisher2 -= 1;
                            _collisionComponent2.Remove(entity);
                            _entities2.Remove(entity);
                            countdown = 1f;
                            ext = false;
                            _Ext -= 1;
                            countstart = false;
                            break;
                        }
                    }

                    if (entity is Itemuse2)
                    {
                        if (((Itemuse2)entity).Item() && itemaxe >= 1)
                        {
                            axe = true;
                        }
                    }
                    if (entity is aex_item)
                    {
                        if (!((aex_item)entity).IsExist())
                        {
                            _collisionComponent2.Remove(entity);
                            MediaPlayer.Play(pick_up_item);
                            _entities2.Remove(entity);
                            itemaxe += 1;
                            break;
                        }
                    }
                    if (entity is DoorEntity)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.F) && axe && itemaxe >= 1)
                        {
                            countstart = true;
                        }
                        if (countdown == 0 && itemaxe >= 1)
                        {
                            itemaxe -= 1;
                            _collisionComponent2.Remove(entity);
                            _entities2.Remove(entity);
                            countdown = 1f;
                            axe = false;
                            countstart = false;
                            break;
                        }
                    }



                    if (entity is NpcEntity)
                    {
                        if (((NpcEntity)entity).IsRescue())
                        {
                            //_collisionComponent2.Remove(entity);
                            MediaPlayer.Volume = 1f;
                            MediaPlayer.Play(pick_up_npc);
                            _entities2.Remove(entity);
                            rescuenum += 1;
                            _thisScore += 100;
                            break;
                        }
                        /*if (((NpcEntity)entity).AllRescue())
                        {
                            rescue = true;
                        }*/
                    }
                    if (entity is NpcEntity2)
                    {
                        if (((NpcEntity2)entity).IsRescue())
                        {
                            //_collisionComponent2.Remove(entity);
                            MediaPlayer.Volume = 1f;
                            MediaPlayer.Play(pick_up_npc);
                            _entities2.Remove(entity);
                            rescuenum += 1;
                            _thisScore += 100;
                            break;
                        }
                        /*if (((NpcEntity)entity).AllRescue())
                        {
                            rescue = true;
                        }*/
                    }

                    if (entity is PlatformEntityTrap)
                    {
                        if (((PlatformEntityTrap)entity).ISHIT())
                        {
                            istrap = true;
                        }
                    }

                    if (entity is BrokenEntity2)
                    {
                        if (!((BrokenEntity2)entity).Past())
                        {
                            ((BrokenEntity2)entity).Bounds.Position = ((BrokenEntity2)entity).Oldpos;

                        }
                        if (((BrokenEntity2)entity).Trap() && !death && HEALTH() > 0)
                        {
                            MediaPlayer.Volume = 1f;
                            MediaPlayer.Play(hit_stone);
                        }
                    }
                    if (entity is BrokenEntity3)
                    {
                        if (!((BrokenEntity3)entity).Past())
                        {
                            ((BrokenEntity3)entity).Bounds.Position = ((BrokenEntity3)entity).Oldpos;

                        }
                    }
                    if (entity is BrokenEntity4)
                    {
                        if (!((BrokenEntity4)entity).Past())
                        {
                            ((BrokenEntity4)entity).Bounds.Position = ((BrokenEntity4)entity).Oldpos;

                        }
                    }


                    if (entity is PlayerEntity)
                    {
                        float tempX = ((PlayerEntity)entity).Bounds.Position.X;
                        float tempY = ((PlayerEntity)entity).Bounds.Position.Y;
                        temp_player_pos = new Vector2(tempX, tempY);
                        _HP = (((PlayerEntity)entity).HEALTH());
                        if (((PlayerEntity)entity).IsHit())
                        {
                            istrap = false;
                        }
                        if (((PlayerEntity)entity).BURN())
                        {
                            MediaPlayer.Volume = 1f;
                            MediaPlayer.Play(hit_fire);
                        }
                        if (((PlayerEntity)entity).INVISIBLE())
                        {
                            invi = true;
                        }
                        if (!((PlayerEntity)entity).INVISIBLE())
                        {
                            invi = false;
                        }
                        if (((PlayerEntity)entity).DEATH())
                        {
                            death = true;
                        }
                        if (!((PlayerEntity)entity).DEATH())
                        {
                            death = false;
                        }
                        if (Keyboard.GetState().IsKeyDown(Keys.Enter) && death && time_counter <= 0)
                        {
                            time_counter = 181;

                        }
                        //((BrokenEntity)entity).Bounds.Position = ((BrokenEntity)entity).Oldpos;


                    }

                    entity.Update(gameTime);
                }
                _camera.LookAt(temp_player_pos + _cameraPosition);
            }
          
            if (isscore == true &&isMenu == false&&isTutorial == false && isGameplay2 == false && isGameplay1 == false)
            {
                Updatescore();
               // MediaPlayer.Volume = 1f;
                //MediaPlayer.Play(you_died);

                if (Keyboard.GetState().IsKeyDown(Keys.E))
                {
                    isMenu = true;
                    isTutorial = false;
                    isGameplay1 = false;
                    isGameplay2 = false;
                    isscore = false;
                    rescuenum = 0;
                    time_counter = 60;
                    MediaPlayer.Play(Menubgm);
                    MediaPlayer.IsRepeating = true;
                    MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
                }
                _camera.LookAt(_cameraPosition+temp_map_pos );
            }
            
            _prototypetiledMapRenderer.Update(gameTime);
            _Gameplay1tiledMapRenderer.Update(gameTime);
            _Gameplay2tiledMapRenderer.Update(gameTime);
            
            _collisionComponent.Update(gameTime);
            _collisionComponent1.Update(gameTime);
            _collisionComponent2.Update(gameTime);
            // _camera.LookAt(temp_player_pos + _cameraPosition);
            //_camera.BoundingRectangle.Y;
            // _cameraPosition.X

            time_counter = time_counter - gameTime.ElapsedGameTime.TotalSeconds;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            var transformMatrix = _camera.GetViewMatrix();

            //_tiledMapRenderer.Draw(transformMatrix);

            if (isTutorial == true)
            {
                Drawpototype();
            }

            if (isGameplay1 == true)
            {
                DrawGameplay1();
            }
            if (isGameplay2 == true)
            {
                DrawGameplay2();
            }


            if (isGameplay2 == true)
            {
                DrawGameplay2();
            }


            _spriteBatch.Begin(transformMatrix: transformMatrix);

            if (isMenu == true)
            {
                //DrawMenu();
                _spriteBatch.Draw(MapMenu, new Vector2(-1200, -800) , Color.White);
                _spriteBatch.Draw(Idle, new Vector2(-120, 130) , new Rectangle(frame * 240, 0, 240, 240), Color.White);
                for (int i = 0; i < menu_listTexts.Count; i++)
                {
                    _spriteBatch.DrawString(Fontforgame, menu_listTexts[i], menu_listVec2[i] , Color.White);
                }
            }
            if (isTutorial == true)
            {
                for (int i = 0; i < m_listTexts.Count; i++)
                {
                    _spriteBatch.DrawString(Fontforgame, m_listTexts[i], m_listVec2[i], Color.White);
                }
                //string str = "Time : " + (int)(time_counter);
                string HP = "HP : " + _HP;
                string _EXT = "EXT : " + _Ext;
                string Axe = "Axe : " + itemaxe;
                _spriteBatch.DrawString(Fontforgame, _EXT, temp_player_pos + new Vector2(-1100, 600), Color.White);

                _spriteBatch.Draw(ItemExt, temp_player_pos + new Vector2(-1200, 600), Color.White);

                _spriteBatch.DrawString(Fontforgame, Axe, temp_player_pos + new Vector2(-350, 600), Color.White);

                _spriteBatch.Draw(ItemAxe, temp_player_pos + new Vector2(-500, 600), Color.White);
                

                if (invi == true)
                {
                    _spriteBatch.Draw(invisible, temp_player_pos + new Vector2(60, -120), Color.White);
                }

                if ((ext == true || axe == true))
                {
                    _spriteBatch.Draw(Press_F, temp_player_pos + new Vector2(0, -240), Color.White);

                }


                DrawpototypeRec();
            }
            if (isGameplay2 == true)
            {
               // string str = "Time : " + (int)(time_counter);
                string HP = "HP : " + _HP;
                string _EXT = "EXT : " + _Ext;
                string Axe = "Axe : " + itemaxe;
                _spriteBatch.DrawString(Fontforgame, _EXT, temp_player_pos + new Vector2(-1100, 600), Color.White);

                _spriteBatch.Draw(ItemExt, temp_player_pos + new Vector2(-1200, 600), Color.White);

                _spriteBatch.DrawString(Fontforgame, Axe, temp_player_pos + new Vector2(-350, 600), Color.White);

                _spriteBatch.Draw(ItemAxe, temp_player_pos + new Vector2(-500, 600), Color.White);
                if (invi == true)
                {
                    _spriteBatch.Draw(invisible, temp_player_pos + new Vector2(60, -120), Color.White);
                }
                if ((ext == true || axe == true))
                {
                    _spriteBatch.Draw(Press_F, temp_player_pos + new Vector2(0, -240), Color.White);

                }
                DrawGameplayRec2();
            }

            if (isGameplay1 == true)
            {
                //string str = "Time : " + (int)(time_counter);
                string HP = "HP : " + _HP;
                string _EXT = "EXT : " + _Ext;
                string Axe = "Axe : " + itemaxe;
                _spriteBatch.DrawString(Fontforgame, _EXT, temp_player_pos + new Vector2(-1100, 600), Color.White);

                _spriteBatch.Draw(ItemExt, temp_player_pos + new Vector2(-1200, 600), Color.White);

                _spriteBatch.DrawString(Fontforgame, Axe, temp_player_pos + new Vector2(-350, 600), Color.White);

                _spriteBatch.Draw(ItemAxe, temp_player_pos + new Vector2(-500, 600), Color.White);
                if (invi == true)
                {
                    _spriteBatch.Draw(invisible, temp_player_pos + new Vector2(60, -120), Color.White);
                }
                if ((ext == true || axe == true))
                {
                    _spriteBatch.Draw(Press_F, temp_player_pos + new Vector2(0, -240), Color.White);

                }
                DrawGameplayRec1();
            }

            if (isscore == true)
            {
                string Showscore = "SCORE:" + _thisScore;
                _spriteBatch.DrawString(Fontforgame, Showscore,new Vector2(-185,0)+ temp_map_pos , Color.White);

                for (int i = 0; i < score_listTexts.Count; i++)
                {
                    _spriteBatch.DrawString(Fontforgame, score_listTexts[i], score_listVec2[i] + temp_map_pos, Color.White);
                }
            }

            // string Text = "Press a or d to control Brian";
            string str = "Time : " + (int)(time_counter);
            string Textreborn = "Press Enter to reborn";
            
            //_spriteBatch.DrawString(Fontforgame, str, temp_player_pos + new Vector2(0, -300), Color.White);
            if(death == true)
            {
                _spriteBatch.DrawString(Fontforgame, Textreborn, temp_player_pos + new Vector2(-550, -100), Color.White);
            }
            
            //_spriteBatch.DrawString(Fontforgame, HP, temp_player_pos + new Vector2(0, -600), Color.White);


            //_spriteBatch.DrawString(Fontforgame, Text, _TextforTutorialtile +new Vector2(0, 1900), Color.White);


            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public int GetMapWidth()
        {
            return MapWidth;
        }
        public int GetMapHeigh()
        {
            return MapHeight;
        }

        public void UpdateCamera(Vector2 Move)
        {
            _cameraPosition += Move;
        }

        public float GetCameraPositionX()
        {
            return _cameraPosition.X;
        }

        public float GetCameraPositionY()
        {
            return _cameraPosition.Y;
        }

        public void Setcam(Vector2 Cam)
        {
            _cameraPosition = Cam;
            
        }

      
        private void UpdateMenu()
        {

            /*if (Keyboard.GetState().IsKeyDown(Keys.B) == true)
            {
                isTutorial = false;
                isGameplay = true;
                // isGameplay2 = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.T) == true)
            {
                //isGameplay2 = true;
                isGameplay = false;
                isTutorial = true;
                //playerPos = new Vector2(300, 300);
                //direction = 0;
            }*/
        }
        private void UpdateTutorial()
        {
            /*if (Keyboard.GetState().IsKeyDown(Keys.B) == true)
            {
                isTutorial = false;
                isGameplay = true;
                // isGameplay2 = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.T) == true)
            {
                //isGameplay2 = true;
                isGameplay = false;
                isTutorial = true;
                //playerPos = new Vector2(300, 300);
                //direction = 0;
            }*/
        }
        private void UpdateGameplay2()
        {
            /*if (Keyboard.GetState().IsKeyDown(Keys.T) == true)
            {
                isTutorial = true;
                isGameplay = false;
                //isGameplay2 = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.B) == true)
            {
                isTutorial = false;
                isGameplay = true;
                //isGameplay2 = false;
            }*/
           
        }
        private void UpdateGameplay1()
        {
            /*if (Keyboard.GetState().IsKeyDown(Keys.B) == true)
  {
      isTutorial = false;
      isGameplay = true;
      // isGameplay2 = false;
  }
  if (Keyboard.GetState().IsKeyDown(Keys.T) == true)
  {
      //isGameplay2 = true;
      isGameplay = false;
      isTutorial = true;
      //playerPos = new Vector2(300, 300);
      //direction = 0;
  }*/

        }
        
     private void Updatescore()
            {
                /*if (Keyboard.GetState().IsKeyDown(Keys.B) == true)
                {
                    isTutorial = false;
                    isGameplay = true;
                    // isGameplay2 = false;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.T) == true)
                {
                    //isGameplay2 = true;
                    isGameplay = false;
                    isTutorial = true;
                    //playerPos = new Vector2(300, 300);
                    //direction = 0;
                }*/
            }
        private void DrawMenu()
        {
            var transformMatrix = _camera.GetViewMatrix();
            //_MENUMapRenderer.Draw(transformMatrix);
        }
        private void DrawMenuRec()
        {
            /*foreach (IEntity entity in _entitiesmenu)
            {
                entity.Draw(_spriteBatch);
            }*/
        }

        private void DrawGameplay2()
        {
            var transformMatrix = _camera.GetViewMatrix();
            _Gameplay2tiledMapRenderer.Draw(transformMatrix);
        }
        private void DrawGameplayRec2()
        {
            foreach (IEntity entity in _entities2)
            {
                entity.Draw(_spriteBatch);
            }
        }
        private void DrawGameplay1()
        {
            var transformMatrix = _camera.GetViewMatrix();
            _Gameplay1tiledMapRenderer.Draw(transformMatrix);
        }
        private void DrawGameplayRec1()
        {
            foreach (IEntity entity in _entities1)
            {
                entity.Draw(_spriteBatch);
            }
        }

        private void Drawpototype()
        {
            var transformMatrix = _camera.GetViewMatrix();
            _prototypetiledMapRenderer.Draw(transformMatrix);
        }

        private void DrawpototypeRec()
        {
            foreach (IEntity entity in _entities)
            {
                entity.Draw(_spriteBatch);
            }
        }
        
        public bool ISTRAP()
        {
            return istrap;
            
        }
        
        public Vector2 Playpos()
        {
            return temp_player_pos;
        }

        public bool EXT()
        {
            return ext;
        }
        public bool AXE()
        {
            return axe;
        }
        public double Time()
        {
            return (int)time_counter;
        }
        public bool ISMENU()
        {
            return isMenu;
        }
        public bool ISTUTORIAL()
        {
            return isTutorial;
        }
        public bool ISGAMEPLAY()
        {
            return isGameplay1;
        }
        public bool ISGAMEPLAY2()
        {
            return isGameplay2;
        }
        public bool ISSCORE()
        {
            return isscore;
        }
        public int HEALTH()
        {
            return _HP;
        }

        void UpdateFrame(float elapsed)
        {
            totalElapsed += elapsed;
            if (totalElapsed > timePerFrame)
            {
                frame = (frame + 1) %3 ;
                totalElapsed -= timePerFrame;
            }
        }
    }   
}
