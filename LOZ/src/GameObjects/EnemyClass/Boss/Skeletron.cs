using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Factories;
using LOZ.Collision;
using LOZ.GameStateReference;
using LOZ.SpriteClasses;
using System.Collections.Generic;
using LOZ.ItemsClasses;

namespace LOZ.EnemyClass
{
    class Skeletron : AbstractEnemy
    {
        private List<IGameObjects> _roomObjects;

        private Color c = Color.White;
        private ISpriteRotatable head, leftArmBone, rightArmBone;

        private Hand leftHand, rightHand;
        private const double ropeDist = 350;  
        
        private int FramesPerUpdate = 500;
        private int updates = 0;


        #region physics
        private const float dt = 1f;
        private protected Vector2 skeletronV;   
        private float rotation = 0.0f;
        private const float radiansInCircle = 6.283f;
        private const float speedTo = 4f;
        private const float speedAway = 5f;
        #endregion

        public Skeletron(Point location, List<IGameObjects> roomObjects)
        {
            leftArmBone = EnemySpriteFactory.Instance.CreateArmBone(true);
            rightArmBone = EnemySpriteFactory.Instance.CreateArmBone(false);
            leftArmBone.Scale = 3;
            rightArmBone.Scale = 3;
            _roomObjects = roomObjects;
            Health = 25;
            Position = location;
            head = EnemySpriteFactory.Instance.CreateSkeletonHead();
            head.Scale = 3.0;
            skeletronV = new Vector2(0, 0);

            rightHand = new Hand(location + new Point(20, 20), false);
            leftHand = new Hand(location + new Point(-20, 20), true);
            roomObjects.Add(leftHand);
            roomObjects.Add(rightHand);
        }

        public override Hitbox GetHitBox() => new Hitbox(Position.X - 28, Position.Y - 28, 56, 56);

        public override bool IsActive()
        {
            if (Health <= 0)
            {
                _roomObjects.Remove(leftHand);
                _roomObjects.Remove(rightHand);
                _roomObjects.Add(new Triforce(Position));
                return false;
            }

            return true;
        }
        private void UpdateVariables()
        {
            updates++;
            if (updates >= FramesPerUpdate * 2)
                updates = 0;
        }
        public override void Update(GameTime timer)
        {
            UpdateVariables();

            if (updates < FramesPerUpdate)
            {
                leftHand.AddForce(GetHandForces(leftHand, random.Next(0,2)));
                rightHand.AddForce(GetHandForces(rightHand, random.Next(0, 2)));
                if (radiansInCircle - rotation > .05f)
                    rotation += .05f; //rotate head to normal stop
            }
            else if (updates >= FramesPerUpdate)
            {
                //move him towards link
                Point lPos = RoomReference.GetLink().Position;
                skeletronV = new Vector2(
                        lPos.X - Position.X,
                        lPos.Y - Position.Y
                    );
                skeletronV = skeletronV + new Vector2(0.1f, 0.1f);
                skeletronV.Normalize();
                skeletronV = skeletronV * new Vector2(2.7f, 2.7f);
                rotation += 0.05f;            
            }
            if (rotation > radiansInCircle)
                rotation = .05f;          

            if (IsDamaged)
            { //limit his damage time
                timeLeftDamage--;
                if (timeLeftDamage <= 0)
                    IsDamaged = false;
            }

            Position = new Point(Position.X + (int)skeletronV.X, Position.Y + (int)skeletronV.Y);
        }
        private Vector2 GetHandForces(Hand refHand, int attack)
        {
            Vector2 returnVector = new Vector2();
            
            //Gets how far the hand is from skeletron
            double leftHandDistance = Math.Sqrt(Math.Pow(Position.X - refHand.Position.X, 2.0) + Math.Pow(Position.Y - refHand.Position.Y, 2.0));
            if (leftHandDistance > ropeDist)
            {
                Vector2 fBack = new Vector2(
                    Position.X - refHand.Position.X, //distance in x pixels to head
                    Position.Y - refHand.Position.Y //distance in y pixels to head
                );
                fBack.Normalize(); //normalizes vector to magnitude of 1
                fBack = fBack * new Vector2(speedAway, speedAway); //doubles the vectors force
                returnVector += fBack;
            }
            if (attack == 0) return returnVector;

            //Gets smaller force towards link
            Point lPos = GameStateReference.RoomReference.GetLink().Position;
            Vector2 fTo = new Vector2(
                    lPos.X - refHand.Position.X + (float)(random.NextDouble() * 1.0),
                    lPos.Y - refHand.Position.Y + (float)(random.NextDouble() * 1.0)
                );
            fTo.Normalize();
            fTo = fTo * new Vector2(speedTo, speedTo);
            returnVector += fTo;
            return returnVector;
        }
        public override void Draw(SpriteBatch spriteBatch, Point offset)
        {
            if (IsDamaged)
                c = Color.Red;
            else
                c = Color.White;
            double angle1 = Math.Atan2(-Position.X - leftHand.Position.X, Position.Y - leftHand.Position.Y);
            double angle2 = Math.Atan2(-Position.X - rightHand.Position.X, Position.Y - rightHand.Position.Y);

            head.Draw(spriteBatch, Position + offset, c, rotation);
            leftArmBone.Draw(spriteBatch, Position + new Point((leftHand.Position.X - Position.X) / 2, (leftHand.Position.Y - Position.Y) / 2) + offset, c, (float)angle1);
            rightArmBone.Draw(spriteBatch, Position + new Point((rightHand.Position.X - Position.X) / 2, (rightHand.Position.Y - Position.Y) / 2) + offset, c, (float)angle2);
        }
    }
}
