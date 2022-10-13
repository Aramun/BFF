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
using BFF;

namespace Prototype02
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        const int MapWidth = 8400;
        const int MapHeight = 3600;

        public static OrthographicCamera _camera;
        public static Vector2 _cameraPosition;
        public static Vector2 _bgPosition;

        TiledMap _tileMap;
        TiledMapRenderer _tiledMapRenderer;

        private readonly List<IEntity> _entities = new List<IEntity>();
        public readonly CollisionComponent _collisionComponent;

        TiledMapObjectLayer _PlatformTiledObj;
        TiledMapObjectLayer _FireObj;
        TiledMapObjectLayer _Fire2Obj;
        TiledMapObjectLayer _Fire3Obj;
        TiledMapObjectLayer _Fire4Obj;
        TiledMapObjectLayer _NpcObj;
        TiledMapObjectLayer _Npc2Obj;
        TiledMapObjectLayer _GoalObj;
        TiledMapObjectLayer _Goal2Obj;
        /*TiledMapObjectLayer _BrokenObj;
        Texture2D Broken;

        bool rescue;*/
        public int rescuenum;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            //_graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
            _collisionComponent = new CollisionComponent(new RectangleF(0, 0, MapWidth, MapHeight));
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 2400  ;
            _graphics.PreferredBackBufferHeight = 1200 ;
            _graphics.ApplyChanges();

            var Viewportadapter = new BoxingViewportAdapter(Window, GraphicsDevice, MapWidth/3, MapHeight/3  );
            _camera = new OrthographicCamera(Viewportadapter);
            //rescue = false;
            _bgPosition = new Vector2(0, 0);
            //Hello World


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _tileMap = Content.Load<TiledMap>("Map_4");
            _tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tileMap);

            foreach (TiledMapObjectLayer layer in _tileMap.ObjectLayers)
            {
              if (layer.Name == "Platform_Object")
            {
              _PlatformTiledObj = layer;
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
                /*if (layer.Name == "Broken_Object")
                {
                    _BrokenObj = layer;
                }*/
              
                if (layer.Name == "Goal_Object")
                {
                    _GoalObj = layer;
                }
                if (layer.Name == "Goal_Object2")
                {
                    _Goal2Obj = layer;
                }
            }

            foreach (TiledMapObject Obj in _PlatformTiledObj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X, Obj.Position.Y);
                _entities.Add(new PlatformEntity(this, new RectangleF(position, Obj.Size)));
            }

            SpriteSheet fireSheet = Content.Load<SpriteSheet>("Resources/fire Sprite sheet.sf", new JsonContentLoader());
            foreach (TiledMapObject Obj in _FireObj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width/2, Obj.Position.Y + Obj.Size.Width/2);
                _entities.Add(new FireEntity(this, new CircleF(position, Obj.Size.Width/2), new AnimatedSprite(fireSheet)));
            }
            foreach (TiledMapObject Obj in _Fire2Obj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 2);
                _entities.Add(new FireEntity2(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(fireSheet)));
            }
            SpriteSheet fireSheet3 = Content.Load<SpriteSheet>("Resources/fire Sprite sheet fire 3.sf", new JsonContentLoader());
            foreach (TiledMapObject Obj in _Fire3Obj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 2);
                _entities.Add(new FireEntity3(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(fireSheet3)));
            }
            SpriteSheet fireSheet4 = Content.Load<SpriteSheet>("Resources/fire pillar Sprite sheet.sf", new JsonContentLoader());
            foreach (TiledMapObject Obj in _Fire4Obj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width / 2, Obj.Position.Y + Obj.Size.Width / 2);
                _entities.Add(new FireEntity4(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(fireSheet4)));
            }

            SpriteSheet npcSheet = Content.Load<SpriteSheet>("Resources/NPC sprite sheet.sf", new JsonContentLoader());
            foreach (TiledMapObject Obj in _NpcObj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width, Obj.Position.Y + Obj.Size.Width);
                _entities.Add(new NpcEntity(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(npcSheet)));
            }
            foreach (TiledMapObject Obj in _Npc2Obj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width, Obj.Position.Y + Obj.Size.Width);
                _entities.Add(new NpcEntity2(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(npcSheet)));
            }

            SpriteSheet goalSheet = Content.Load<SpriteSheet>("Resources/goal sprite sheet.sf", new JsonContentLoader());
            foreach (TiledMapObject Obj in _GoalObj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width, Obj.Position.Y + Obj.Size.Width);
                _entities.Add(new GoalEntity(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(goalSheet)));
            }
            foreach (TiledMapObject Obj in _Goal2Obj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width, Obj.Position.Y + Obj.Size.Width);
                _entities.Add(new GoalEntity2(this, new CircleF(position, Obj.Size.Width / 2), new AnimatedSprite(goalSheet)));
            }

            /*Broken = Content.Load<Texture2D>("Resources/woodfix");
            foreach(TiledMapObject Obj in _BrokenObj.Objects)
            {
                Point2 position = new Point2(Obj.Position.X + Obj.Size.Width , Obj.Position.Y + Obj.Size.Width );
                _entities.Add(new BrokenEntity(this, new CircleF(position, Obj.Size.Width), Broken));
            }*/


            SpriteSheet playerSheet = Content.Load<SpriteSheet>("Resources/Sprite Sheet Char.sf", new JsonContentLoader());
            _entities.Add(new PlayerEntity(this, new RectangleF(new Vector2(0,0), new Size2(240, 240)), new AnimatedSprite(playerSheet)));

            foreach (IEntity entity in _entities)
            {
                _collisionComponent.Insert(entity);
            }


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Vector2 temp_player_pos = Vector2.Zero;
            foreach (IEntity entity in _entities)
            {
                if(entity is FireEntity)
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
                if(entity is GoalEntity)
             {
                 if (((GoalEntity)entity).IsRescue() && rescuenum == 2)
                 {
                     Exit();
                 }
             }
                if (entity is GoalEntity2)
            {
                    if (((GoalEntity2)entity).IsRescue() && rescuenum == 2)
                 {
                        Exit();
                 }
            }

                /*if (entity is NpcEntity)
                {
                    if (((NpcEntity)entity).IsRescue())
                    {
                        //_collisionComponent.Remove(entity);
                        _entities.Remove(entity);
                        rescuenum += 1;
                        break;
                    }
                    /*if (((NpcEntity)entity).AllRescue())
                    {
                        rescue = true;
                    }*/
                //}





                /*if (entity is BrokenEntity)
                {
                    if (!((BrokenEntity)entity).Past())
                    {
                        //((BrokenEntity)entity).Bounds.Position = ((BrokenEntity)entity).Oldpos;
                        
                    }
                }*/

                if (entity is PlayerEntity)
                {
                    float tempX = ((PlayerEntity)entity).Bounds.Position.X;
                    float tempY = ((PlayerEntity)entity).Bounds.Position.Y;
                    temp_player_pos = new Vector2(tempX, tempY);
                    //((BrokenEntity)entity).Bounds.Position = ((BrokenEntity)entity).Oldpos;


                }
                entity.Update(gameTime);
            }

            _collisionComponent.Update(gameTime);
            _tiledMapRenderer.Update(gameTime);
            _camera.LookAt(temp_player_pos + _cameraPosition);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            var transformMatrix = _camera.GetViewMatrix();

            _tiledMapRenderer.Draw(transformMatrix);
            _spriteBatch.Begin(transformMatrix:transformMatrix);
            foreach (IEntity entity in _entities)
            {
                entity.Draw(_spriteBatch);
            }
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
    }   
}
