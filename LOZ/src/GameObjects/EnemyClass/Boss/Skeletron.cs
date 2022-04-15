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
        private List<Hand> hands = new List<Hand>();
        
        private int FramesPerUpdate = 500;
        private int updates = 0;
        private bool attackingWithLeft = false;

        #region physics
        private const double handDistMax = 240;
        private const float dt = 1f;
        private protected Vector2 skeletronV;   
        private float rotation = 0.0f;
        private const float radiansInCircle = 6.283f;
        private const float speedTo = 5.8f;
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
            hands.Add(leftHand);
            hands.Add(rightHand);
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
        public override void Update(GameTime timer)
        {
            updates++;
            DragHand(leftHand);
            DragHand(rightHand);
            if (updates < FramesPerUpdate)
                HandAttacks();
            if (updates < FramesPerUpdate / 2)
                attackingWithLeft = !attackingWithLeft;
            if (updates >= FramesPerUpdate)
                SpinnyHeadAttack();
            if (updates >= FramesPerUpdate * 2)
                updates = 0;

            if (rotation > radiansInCircle)
                rotation = .05f;
            UpdateDamageState();
            UpdateHeadPosition();
            UpdateVelocity();
        }

        public override void Draw(SpriteBatch spriteBatch, Point offset)
        {
            if (IsDamaged)
                c = Color.Red;
            else
                c = Color.White;
            double angle1 = Math.Atan2(Position.Y - leftHand.Position.Y,Position.X - leftHand.Position.X);
            double angle2 = Math.Atan2(Position.Y - rightHand.Position.Y, Position.X - rightHand.Position.X);

            head.Draw(spriteBatch, Position + offset, c, rotation);
            leftArmBone.Draw(spriteBatch, Position + new Point((leftHand.Position.X - Position.X) / 2, (leftHand.Position.Y - Position.Y) / 2) + offset, c, (float)angle1);
            rightArmBone.Draw(spriteBatch, Position + new Point((rightHand.Position.X - Position.X) / 2, (rightHand.Position.Y - Position.Y) / 2) + offset, c, (float)angle2);
        }
        #region SkeletronMovements
        private void SpinnyHeadAttack()
        {
            MoveHeadToPosition(RoomReference.GetLink().Position);
            rotation += .10f;
        }

        private void HandAttacks()
        {
            if (radiansInCircle - rotation > .10f)
                rotation += .10f;
            if (attackingWithLeft) AttackHandToPosition(leftHand, RoomReference.GetLink().Position);
            else AttackHandToPosition(rightHand, RoomReference.GetLink().Position);
        }
        private void DragHand(Hand hand)
        {
            double handDistance = Math.Sqrt(Math.Pow(Position.X - hand.Position.X, 2.0) + Math.Pow(Position.Y - hand.Position.Y, 2.0));
            if (handDistance < handDistMax) return;
            Vector2 fBack = new Vector2(
                Position.X - hand.Position.X, //distance in x pixels to head
                Position.Y - hand.Position.Y //distance in y pixels to head
            );
            fBack.Normalize();
            fBack = fBack * new Vector2(speedAway, speedAway);
            hand.AddForce(fBack);

        }
        private void AttackHandToPosition(Hand hand, Point p)
        {
            Vector2 fTo = new Vector2(
                p.X - hand.Position.X,
                p.Y - hand.Position.Y
            );
            fTo.Normalize();
            fTo = fTo * new Vector2(speedTo, speedTo);
            hand.AddForce(fTo);
        }

        private void MoveHeadToPosition(Point p)
        {
            Point lPos = RoomReference.GetLink().Position;
            skeletronV = new Vector2(
                    lPos.X - Position.X,
                    lPos.Y - Position.Y
                );
            skeletronV = skeletronV + new Vector2(0.1f, 0.1f);
            skeletronV.Normalize();
            skeletronV = skeletronV * new Vector2(2.7f, 2.7f);
        }

        private void UpdateDamageState()
        {
            if (IsDamaged)
            { //limit his damage time
                timeLeftDamage--;
                if (timeLeftDamage <= 0)
                    IsDamaged = false;
            }
        }
        private void UpdateHeadPosition() => Position = new Point(Position.X + (int)skeletronV.X, Position.Y + (int)skeletronV.Y);
        private void UpdateVelocity()
        {
            skeletronV.X -= skeletronV.X / 10f;
            skeletronV.Y -= skeletronV.Y / 10f;
        }
        #endregion
    }
}
