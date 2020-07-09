using _2DGameEngine.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _2DGameEngine.Particles
{
    public enum ParticleDepthSorting
    {
        AboveEntities, UnderEntities, SortByY
    }
    public class ParticlePool
    {
        public Particle[] Array { get; }
        public ParticleSystem ParticleSystem { get; }
        public int InactiveIndex { get; set; }
        public ParticleComponent ParticleComponent { get; set; }
        public ParticleDepthSorting DepthSorting { get; set; }
        public ParticlePool(int count, ParticleComponent component, ParticleDepthSorting depthSorting, ParticleSystem particleSystem)
        {
            Array = new Particle[count];
            ParticleComponent = component;
            DepthSorting = depthSorting;
            ParticleSystem = particleSystem;
            InactiveIndex = count-1;
        }
        public void Draw(ref float layerDepth)
        {
            if (DepthSorting == ParticleDepthSorting.AboveEntities || DepthSorting == ParticleDepthSorting.UnderEntities)
            {
                float biggestTicks = 0f;
                for (int i = Array.Length - 1; i > InactiveIndex; i--)
                {
                    var particle = Array[i];
                    float depth = layerDepth + (particle.Ticks + 1) / 10000000f;
                    RenderContext.SpriteBatch.Draw(particle.Texture, new Rectangle(particle.Position, particle.Size), particle.SourceRectangle, Color.White * particle.Opacity, particle.Rotation, new Vector2(), SpriteEffects.None, depth);
                    if (particle.Ticks + 1 > biggestTicks) biggestTicks = particle.Ticks + 1;
                }
                layerDepth += biggestTicks / 10000000f;
            }
            else if (DepthSorting == ParticleDepthSorting.SortByY)
            {
                float biggestDepth = 0f;
                for (int i = Array.Length - 1; i > InactiveIndex; i--)
                {
                    var particle = Array[i];
                    int posY = (particle.Position.Y + particle.Size.Y - ParticleSystem.Layer.Scene.Camera.Transform.Position.Y);
                    int activeIndex = i - InactiveIndex - 1;
                    float depth = posY / 10000000f;
                    if (biggestDepth < depth) biggestDepth = depth;
                    RenderContext.SpriteBatch.Draw(particle.Texture, new Rectangle(particle.Position, particle.Size), particle.SourceRectangle, Color.White * particle.Opacity, particle.Rotation, new Vector2(), SpriteEffects.None, layerDepth + depth + activeIndex / (10000000f * (Array.Length - 1 - InactiveIndex)));
                }
                layerDepth += biggestDepth;
            }
        }
    }
}
