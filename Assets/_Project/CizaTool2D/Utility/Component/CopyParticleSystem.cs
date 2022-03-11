using NSubstitute.Exceptions;
using Sirenix.OdinInspector.Editor;
using UnityEngine;

namespace CizaTool2D.Utility.Component
{
    public static class CopyParticleSystem
    {
    #region === Private Methods ====

        public static void CopyParticle(this ParticleSystem toCopy, ParticleSystem from) {
            CopyParticle_Main(toCopy, from);
            CopyParticle_Emission(toCopy, from);
            CopyParticle_Shape(toCopy, from);
            CopyParticle_VelocityOverLifeTime(toCopy, from);
            CopyParticle_LimitVelocityOverLifetime(toCopy, from);
            CopyParticle_InheritVelocity(toCopy, from);
            CopyParticle_LifetimeByEmitterSpeed(toCopy, from);
            CopyParticle_ForceOverLifetime(toCopy, from);
            CopyParticle_ColorOverLifetime(toCopy, from);
            CopyParticle_ColorBySpeed(toCopy, from);
            CopyParticle_SizeOverLifetime(toCopy, from);
            CopyParticle_SizeBySpeed(toCopy, from);
            CopyParticle_RotationOverLifetime(toCopy, from);
            CopyParticle_RotationBySpeed(toCopy, from);
            CopyParticle_ExternalForces(toCopy, from);
            CopyParticle_Noise(toCopy, from);
            CopyParticle_Collision(toCopy, from);
            CopyParticle_Triggers(toCopy, from);
            //CopyParticle_SubEmitters(toCopy, from);
            CopyParticle_TextureSheetAnimation(toCopy, from);
            CopyParticle_Lights(toCopy, from);
            CopyParticle_Trails(toCopy, from);
            //CopyParticle_CustomData(toCopy, from);
            CopyParticle_Renderer(toCopy, from);
        }

        public static void CopyParticle_Main(ParticleSystem toCopy, ParticleSystem from) {
            var main     = toCopy.main;
            var fromMain = from.main;
            main.duration = fromMain.duration;
            main.loop     = fromMain.loop;
            main.prewarm  = fromMain.prewarm;

            main.startDelay    = fromMain.startDelay;
            main.startLifetime = fromMain.startLifetime;
            main.startSpeed    = fromMain.startSpeed;

            main.startSize     = fromMain.startSize;
            main.startRotation = fromMain.startRotation;

            main.flipRotation = fromMain.flipRotation;
            main.startColor   = fromMain.startColor;

            main.gravityModifier = fromMain.gravityModifier;
            main.simulationSpace = fromMain.simulationSpace;
            main.simulationSpeed = fromMain.simulationSpeed;

            main.scalingMode         = fromMain.scalingMode;
            main.emitterVelocityMode = fromMain.emitterVelocityMode;
            main.maxParticles        = fromMain.maxParticles;
            main.stopAction          = fromMain.stopAction;
            main.cullingMode         = fromMain.cullingMode;
            main.ringBufferMode      = fromMain.ringBufferMode;
        }

        public static void CopyParticle_Emission(this ParticleSystem toCopy, ParticleSystem from) {
            var emission     = toCopy.emission;
            var fromEmission = from.emission;

            emission.enabled = fromEmission.enabled;
            if(!emission.enabled)
                return;


            emission.rateOverTime     = fromEmission.rateOverTime;
            emission.rateOverDistance = fromEmission.rateOverDistance;

            ParticleSystem.Burst[] bursts = new ParticleSystem.Burst[fromEmission.burstCount];
            fromEmission.GetBursts(bursts);
            emission.SetBursts(bursts);
        }

        public static void CopyParticle_Shape(this ParticleSystem toCopy, ParticleSystem from) {
            var shape     = toCopy.shape;
            var fromShape = from.shape;

            shape.enabled = fromShape.enabled;
            if(!shape.enabled)
                return;

            shape.shapeType = fromShape.shapeType;
            shape.angle     = fromShape.angle;

            shape.radius          = fromShape.radius;
            shape.radiusThickness = fromShape.radiusThickness;
            shape.donutRadius     = fromShape.donutRadius;
            shape.meshShapeType   = fromShape.meshShapeType;
            shape.spriteRenderer  = fromShape.spriteRenderer;
            shape.mesh            = fromShape.mesh;

            shape.arc       = fromShape.arc;
            shape.arcMode   = fromShape.arcMode;
            shape.arcSpeed  = fromShape.arcSpeed;
            shape.arcSpread = fromShape.arcSpread;

            shape.length                   = fromShape.length;
            shape.texture                  = fromShape.texture;
            shape.position                 = fromShape.position;
            shape.rotation                 = fromShape.rotation;
            shape.scale                    = fromShape.scale;
            shape.alignToDirection         = fromShape.alignToDirection;
            shape.randomDirectionAmount    = fromShape.randomDirectionAmount;
            shape.sphericalDirectionAmount = fromShape.sphericalDirectionAmount;
            shape.randomPositionAmount     = fromShape.randomPositionAmount;
        }

        public static void CopyParticle_VelocityOverLifeTime(this ParticleSystem toCopy, ParticleSystem from) {
            var velocityOverLifeTime     = toCopy.velocityOverLifetime;
            var fromVelocityOverLifeTime = from.velocityOverLifetime;

            velocityOverLifeTime.enabled = fromVelocityOverLifeTime.enabled;
            if(!velocityOverLifeTime.enabled)
                return;

            velocityOverLifeTime.x = fromVelocityOverLifeTime.x;
            velocityOverLifeTime.y = fromVelocityOverLifeTime.y;
            velocityOverLifeTime.z = fromVelocityOverLifeTime.z;

            velocityOverLifeTime.xMultiplier = fromVelocityOverLifeTime.xMultiplier;
            velocityOverLifeTime.yMultiplier = fromVelocityOverLifeTime.yMultiplier;
            velocityOverLifeTime.zMultiplier = fromVelocityOverLifeTime.zMultiplier;

            velocityOverLifeTime.space = fromVelocityOverLifeTime.space;

            velocityOverLifeTime.orbitalX = fromVelocityOverLifeTime.orbitalX;
            velocityOverLifeTime.orbitalY = fromVelocityOverLifeTime.orbitalY;
            velocityOverLifeTime.orbitalZ = fromVelocityOverLifeTime.orbitalZ;

            velocityOverLifeTime.orbitalXMultiplier = fromVelocityOverLifeTime.orbitalXMultiplier;
            velocityOverLifeTime.orbitalYMultiplier = fromVelocityOverLifeTime.orbitalYMultiplier;
            velocityOverLifeTime.orbitalZMultiplier = fromVelocityOverLifeTime.orbitalZMultiplier;

            velocityOverLifeTime.orbitalOffsetX = fromVelocityOverLifeTime.orbitalOffsetX;
            velocityOverLifeTime.orbitalOffsetY = fromVelocityOverLifeTime.orbitalOffsetY;
            velocityOverLifeTime.orbitalOffsetZ = fromVelocityOverLifeTime.orbitalOffsetZ;

            velocityOverLifeTime.orbitalOffsetXMultiplier = fromVelocityOverLifeTime.orbitalOffsetXMultiplier;
            velocityOverLifeTime.orbitalOffsetYMultiplier = fromVelocityOverLifeTime.orbitalOffsetYMultiplier;
            velocityOverLifeTime.orbitalOffsetZMultiplier = fromVelocityOverLifeTime.orbitalOffsetZMultiplier;

            velocityOverLifeTime.radial           = fromVelocityOverLifeTime.radial;
            velocityOverLifeTime.radialMultiplier = fromVelocityOverLifeTime.radialMultiplier;

            velocityOverLifeTime.speedModifier           = fromVelocityOverLifeTime.speedModifier;
            velocityOverLifeTime.speedModifierMultiplier = fromVelocityOverLifeTime.speedModifierMultiplier;
        }

        public static void CopyParticle_LimitVelocityOverLifetime(this ParticleSystem toCopy, ParticleSystem from) {
            var limitVelocityOverLifetime     = toCopy.limitVelocityOverLifetime;
            var fromLimitVelocityOverLifetime = from.limitVelocityOverLifetime;

            limitVelocityOverLifetime.enabled = fromLimitVelocityOverLifetime.enabled;
            if(!limitVelocityOverLifetime.enabled)
                return;

            limitVelocityOverLifetime.separateAxes = fromLimitVelocityOverLifetime.separateAxes;

            limitVelocityOverLifetime.space  = fromLimitVelocityOverLifetime.space;
            limitVelocityOverLifetime.dampen = fromLimitVelocityOverLifetime.dampen;

            limitVelocityOverLifetime.drag = fromLimitVelocityOverLifetime.drag;

            limitVelocityOverLifetime.multiplyDragByParticleSize =
                fromLimitVelocityOverLifetime.multiplyDragByParticleSize;
            limitVelocityOverLifetime.multiplyDragByParticleVelocity =
                fromLimitVelocityOverLifetime.multiplyDragByParticleVelocity;
        }

        public static void CopyParticle_InheritVelocity(this ParticleSystem toCopy, ParticleSystem from) {
            var inheritVelocity     = toCopy.inheritVelocity;
            var fromInheritVelocity = from.inheritVelocity;

            inheritVelocity.enabled = fromInheritVelocity.enabled;
            if(!inheritVelocity.enabled)
                return;

            inheritVelocity.mode            = fromInheritVelocity.mode;
            inheritVelocity.curveMultiplier = fromInheritVelocity.curveMultiplier;
            inheritVelocity.curve           = fromInheritVelocity.curve;
        }


        public static void CopyParticle_LifetimeByEmitterSpeed(this ParticleSystem toCopy, ParticleSystem from) {
            var lifetimeByEmitterSpeed     = toCopy.lifetimeByEmitterSpeed;
            var fromLifetimeByEmitterSpeed = from.lifetimeByEmitterSpeed;

            lifetimeByEmitterSpeed.enabled = fromLifetimeByEmitterSpeed.enabled;
            if(!lifetimeByEmitterSpeed.enabled)
                return;

            lifetimeByEmitterSpeed.range           = fromLifetimeByEmitterSpeed.range;
            lifetimeByEmitterSpeed.curve           = fromLifetimeByEmitterSpeed.curve;
            lifetimeByEmitterSpeed.curveMultiplier = fromLifetimeByEmitterSpeed.curveMultiplier;
        }

        public static void CopyParticle_ForceOverLifetime(this ParticleSystem toCopy, ParticleSystem from) {
            var forceOverLifetime     = toCopy.forceOverLifetime;
            var fromForceOverLifetime = from.forceOverLifetime;

            forceOverLifetime.enabled = fromForceOverLifetime.enabled;
            if(!forceOverLifetime.enabled)
                return;

            forceOverLifetime.x = fromForceOverLifetime.x;
            forceOverLifetime.y = fromForceOverLifetime.y;
            forceOverLifetime.z = fromForceOverLifetime.z;

            forceOverLifetime.xMultiplier = fromForceOverLifetime.xMultiplier;
            forceOverLifetime.yMultiplier = fromForceOverLifetime.yMultiplier;
            forceOverLifetime.zMultiplier = fromForceOverLifetime.zMultiplier;

            forceOverLifetime.randomized = fromForceOverLifetime.randomized;
            forceOverLifetime.space      = fromForceOverLifetime.space;
        }

        public static void CopyParticle_ColorOverLifetime(this ParticleSystem toCopy, ParticleSystem from) {
            var colorOverLifetime     = toCopy.colorOverLifetime;
            var fromColorOverLifetime = from.colorOverLifetime;

            colorOverLifetime.enabled = fromColorOverLifetime.enabled;
            if(!colorOverLifetime.enabled)
                return;

            colorOverLifetime.color = fromColorOverLifetime.color;
        }

        public static void CopyParticle_ColorBySpeed(this ParticleSystem toCopy, ParticleSystem from) {
            var colorBySpeed     = toCopy.colorBySpeed;
            var fromColorBySpeed = from.colorBySpeed;

            colorBySpeed.enabled = fromColorBySpeed.enabled;
            if(!colorBySpeed.enabled)
                return;

            colorBySpeed.color = fromColorBySpeed.color;
            colorBySpeed.range = fromColorBySpeed.range;
        }

        public static void CopyParticle_SizeOverLifetime(this ParticleSystem toCopy, ParticleSystem from) {
            var sizeOverLifetime     = toCopy.sizeOverLifetime;
            var fromSizeOverLifetime = from.sizeOverLifetime;

            sizeOverLifetime.enabled = fromSizeOverLifetime.enabled;
            if(!sizeOverLifetime.enabled)
                return;

            sizeOverLifetime.separateAxes = fromSizeOverLifetime.separateAxes;

            sizeOverLifetime.size           = fromSizeOverLifetime.size;
            sizeOverLifetime.sizeMultiplier = fromSizeOverLifetime.sizeMultiplier;

            sizeOverLifetime.x = fromSizeOverLifetime.x;
            sizeOverLifetime.y = fromSizeOverLifetime.y;
            sizeOverLifetime.z = fromSizeOverLifetime.z;

            sizeOverLifetime.xMultiplier = fromSizeOverLifetime.xMultiplier;
            sizeOverLifetime.yMultiplier = fromSizeOverLifetime.yMultiplier;
            sizeOverLifetime.zMultiplier = fromSizeOverLifetime.zMultiplier;
        }

        public static void CopyParticle_SizeBySpeed(this ParticleSystem toCopy, ParticleSystem from) {
            var sizeBySpeed     = toCopy.sizeBySpeed;
            var fromSizeBySpeed = from.sizeBySpeed;

            sizeBySpeed.enabled = fromSizeBySpeed.enabled;
            if(!sizeBySpeed.enabled)
                return;

            sizeBySpeed.separateAxes = fromSizeBySpeed.separateAxes;

            sizeBySpeed.size           = fromSizeBySpeed.size;
            sizeBySpeed.sizeMultiplier = fromSizeBySpeed.sizeMultiplier;

            sizeBySpeed.x = fromSizeBySpeed.x;
            sizeBySpeed.x = fromSizeBySpeed.x;
            sizeBySpeed.x = fromSizeBySpeed.x;

            sizeBySpeed.xMultiplier = fromSizeBySpeed.xMultiplier;
            sizeBySpeed.yMultiplier = fromSizeBySpeed.yMultiplier;
            sizeBySpeed.zMultiplier = fromSizeBySpeed.zMultiplier;

            sizeBySpeed.range = fromSizeBySpeed.range;
        }

        public static void CopyParticle_RotationOverLifetime(this ParticleSystem toCopy, ParticleSystem from) {
            var rotationOverLifetime     = toCopy.rotationOverLifetime;
            var fromRotationOverLifetime = from.rotationOverLifetime;

            rotationOverLifetime.enabled = fromRotationOverLifetime.enabled;
            if(!rotationOverLifetime.enabled)
                return;

            rotationOverLifetime.separateAxes = fromRotationOverLifetime.separateAxes;
            
            rotationOverLifetime.x            = fromRotationOverLifetime.x;
            rotationOverLifetime.y            = fromRotationOverLifetime.y;
            rotationOverLifetime.z            = fromRotationOverLifetime.z;
            
            rotationOverLifetime.xMultiplier = fromRotationOverLifetime.xMultiplier;
            rotationOverLifetime.yMultiplier = fromRotationOverLifetime.yMultiplier;
            rotationOverLifetime.zMultiplier = fromRotationOverLifetime.zMultiplier;
        }

        public static void CopyParticle_RotationBySpeed(this ParticleSystem toCopy, ParticleSystem from) {
            var rotationBySpeed     = toCopy.rotationBySpeed;
            var fromRotationBySpeed = from.rotationBySpeed;

            rotationBySpeed.enabled = fromRotationBySpeed.enabled;
            if(!rotationBySpeed.enabled)
                return;

            rotationBySpeed.separateAxes = fromRotationBySpeed.separateAxes;
            
            rotationBySpeed.x            = fromRotationBySpeed.x;
            rotationBySpeed.y            = fromRotationBySpeed.y;
            rotationBySpeed.z            = fromRotationBySpeed.z;
            
            rotationBySpeed.xMultiplier = fromRotationBySpeed.xMultiplier;
            rotationBySpeed.yMultiplier = fromRotationBySpeed.yMultiplier;
            rotationBySpeed.zMultiplier = fromRotationBySpeed.zMultiplier;

            rotationBySpeed.range = rotationBySpeed.range;
        }

        public static void CopyParticle_ExternalForces(this ParticleSystem toCopy, ParticleSystem from) {
            var externalForces     = toCopy.externalForces;
            var fromExternalForces = from.externalForces;

            externalForces.enabled = fromExternalForces.enabled;
            if(!externalForces.enabled)
                return;

            externalForces.multiplier      = fromExternalForces.multiplier;
            externalForces.influenceFilter = fromExternalForces.influenceFilter;
            externalForces.influenceMask   = fromExternalForces.influenceMask;
        }

        public static void CopyParticle_Noise(this ParticleSystem toCopy, ParticleSystem from) {
            var noise     = toCopy.noise;
            var fromNoise = from.noise;

            noise.enabled = fromNoise.enabled;
            if(!noise.enabled)
                return;

            noise.separateAxes     = fromNoise.separateAxes;
            noise.strength         = fromNoise.strength;
            noise.frequency        = fromNoise.frequency;
            noise.scrollSpeed      = fromNoise.scrollSpeed;
            noise.damping          = fromNoise.damping;
            noise.octaveCount      = fromNoise.octaveCount;
            noise.octaveMultiplier = fromNoise.octaveMultiplier;
            noise.octaveScale      = fromNoise.octaveScale;
            noise.quality          = fromNoise.quality;
            noise.remap            = fromNoise.remap;
            
            noise.remapX = fromNoise.remapX;
            noise.remapY = fromNoise.remapY;
            noise.remapZ = fromNoise.remapZ;
            
            noise.remapXMultiplier = fromNoise.remapXMultiplier;
            noise.remapYMultiplier = fromNoise.remapYMultiplier;
            noise.remapZMultiplier = fromNoise.remapZMultiplier;

            noise.positionAmount = fromNoise.positionAmount;
            noise.rotationAmount = fromNoise.rotationAmount;
            noise.sizeAmount     = fromNoise.sizeAmount;
        }

        public static void CopyParticle_Collision(this ParticleSystem toCopy, ParticleSystem from) {
            var collision     = toCopy.collision;
            var fromCollision = from.collision;

            collision.enabled = fromCollision.enabled;
            if(!collision.enabled)
                return;

            collision.type = fromCollision.type;

            for(int i = 0; i < fromCollision.planeCount; i++)
                collision.SetPlane( i, fromCollision.GetPlane(i));

            collision.dampen           = fromCollision.dampen;
            collision.dampenMultiplier = fromCollision.dampenMultiplier;
            
            collision.bounce           = fromCollision.bounce;
            collision.bounceMultiplier = fromCollision.bounceMultiplier;
            
            collision.lifetimeLoss     = fromCollision.lifetimeLoss;
            
            collision.minKillSpeed          = fromCollision.minKillSpeed;
            collision.maxCollisionShapes    = fromCollision.maxCollisionShapes;
            collision.radiusScale           = fromCollision.radiusScale;
            collision.sendCollisionMessages = fromCollision.sendCollisionMessages;
            
            
            
            collision.mode                   = fromCollision.mode;
            collision.quality                = fromCollision.quality;
            collision.collidesWith           = fromCollision.collidesWith;
            collision.maxCollisionShapes     = fromCollision.maxCollisionShapes;
            collision.enableDynamicColliders = fromCollision.enableDynamicColliders;

            collision.colliderForce                         = fromCollision.colliderForce;
            collision.multiplyColliderForceByCollisionAngle = fromCollision.multiplyColliderForceByCollisionAngle;
            collision.multiplyColliderForceByParticleSpeed  = fromCollision.multiplyColliderForceByParticleSpeed;
            collision.multiplyColliderForceByParticleSize   = fromCollision.multiplyColliderForceByParticleSize;
        }

        public static void CopyParticle_Triggers(this ParticleSystem toCopy, ParticleSystem from) {
            var triggers     = toCopy.trigger;
            var fromTriggers = from.trigger;

            triggers.enabled = fromTriggers.enabled;
            if(!triggers.enabled)
                return;

            for(int i = 0; i < fromTriggers.colliderCount; i++)
                triggers.SetCollider(i, fromTriggers.GetCollider(i));

            triggers.inside            = fromTriggers.inside;
            triggers.outside           = fromTriggers.outside;
            triggers.enter             = fromTriggers.enter;
            triggers.exit              = fromTriggers.exit;
            triggers.colliderQueryMode = fromTriggers.colliderQueryMode;
            triggers.radiusScale       = fromTriggers.radiusScale;
        }

        public static void CopyParticle_SubEmitters(this ParticleSystem toCopy, ParticleSystem from) {
            var cubEmitters     = toCopy.subEmitters;
            var fromSubEmitters = from.subEmitters;

            cubEmitters.enabled = fromSubEmitters.enabled;
            if(!cubEmitters.enabled)
                return;
            
            var count     = cubEmitters.subEmittersCount;
            var fromCount = fromSubEmitters.subEmittersCount;

            if(count > fromCount){
                for(int i = 0; i < count; i++){
                    if(i > fromCount - 1)
                        cubEmitters.RemoveSubEmitter(i);
                    else{
                        cubEmitters.SetSubEmitterSystem(i, fromSubEmitters.GetSubEmitterSystem(i));
                        cubEmitters.SetSubEmitterType(i, fromSubEmitters.GetSubEmitterType(i));
                        cubEmitters.SetSubEmitterProperties(i, fromSubEmitters.GetSubEmitterProperties(i)); 
                        cubEmitters.SetSubEmitterEmitProbability(i, fromSubEmitters.GetSubEmitterEmitProbability(i));
                    }
                }
                
            }
            else{
                for(int i = 0; i < fromCount; i++){
                    if(i > count - 1)
                        cubEmitters.AddSubEmitter(fromSubEmitters.GetSubEmitterSystem(i),
                                                  fromSubEmitters.GetSubEmitterType(i),
                                                  fromSubEmitters.GetSubEmitterProperties(i),
                                                  fromSubEmitters.GetSubEmitterEmitProbability(i));
                    else{
                        cubEmitters.SetSubEmitterSystem(i, fromSubEmitters.GetSubEmitterSystem(i));
                        cubEmitters.SetSubEmitterType(i, fromSubEmitters.GetSubEmitterType(i));
                        cubEmitters.SetSubEmitterProperties(i, fromSubEmitters.GetSubEmitterProperties(i));
                        cubEmitters.SetSubEmitterEmitProbability(i, fromSubEmitters.GetSubEmitterEmitProbability(i));
                    }
                }
            }

        }

        public static void CopyParticle_TextureSheetAnimation(this ParticleSystem toCopy, ParticleSystem from) {
            var textureSheetAnimation     = toCopy.textureSheetAnimation;
            var fromTextureSheetAnimation = from.textureSheetAnimation;

            textureSheetAnimation.enabled = fromTextureSheetAnimation.enabled;
            if(!textureSheetAnimation.enabled)
                return;

            textureSheetAnimation.mode      = fromTextureSheetAnimation.mode;
            
            textureSheetAnimation.numTilesX = fromTextureSheetAnimation.numTilesX;
            textureSheetAnimation.numTilesY = fromTextureSheetAnimation.numTilesY;

            var count     = textureSheetAnimation.spriteCount;
            var fromCount = fromTextureSheetAnimation.spriteCount;

            if(count > fromCount){
                for(int i = 0; i < count; i++){
                    if(i > fromCount - 1)
                        textureSheetAnimation.RemoveSprite(fromCount);  
                    else
                        textureSheetAnimation.SetSprite(i, fromTextureSheetAnimation.GetSprite(i));
                }
                
            }
            else{
                for(int i = 0; i < fromCount; i++){
                    if(i > count - 1)
                        textureSheetAnimation.AddSprite(fromTextureSheetAnimation.GetSprite(i));  
                    else
                        textureSheetAnimation.SetSprite(i, fromTextureSheetAnimation.GetSprite(i));
                }
            }


            textureSheetAnimation.animation     = fromTextureSheetAnimation.animation;
            
            textureSheetAnimation.rowMode  = fromTextureSheetAnimation.rowMode;
            textureSheetAnimation.rowIndex = fromTextureSheetAnimation.rowIndex;
            
            
            textureSheetAnimation.timeMode      = fromTextureSheetAnimation.timeMode;
            textureSheetAnimation.frameOverTime = fromTextureSheetAnimation.frameOverTime;
            textureSheetAnimation.speedRange    = fromTextureSheetAnimation.speedRange;
            
            textureSheetAnimation.fps           = textureSheetAnimation.fps;

            textureSheetAnimation.startFrame           = fromTextureSheetAnimation.startFrame;
            textureSheetAnimation.startFrameMultiplier = fromTextureSheetAnimation.startFrameMultiplier;
            
            textureSheetAnimation.cycleCount           = fromTextureSheetAnimation.cycleCount;
            textureSheetAnimation.uvChannelMask        = fromTextureSheetAnimation.uvChannelMask;
        }

        public static void CopyParticle_Lights(this ParticleSystem toCopy, ParticleSystem from) {
            var lights     = toCopy.lights;
            var fromLights = from.lights;

            lights.enabled = fromLights.enabled;
            if(!lights.enabled)
                return;

            lights.light                 = fromLights.light;
            lights.ratio                 = fromLights.ratio;
            lights.useRandomDistribution = fromLights.useRandomDistribution;
            lights.useParticleColor      = fromLights.useParticleColor;
            lights.sizeAffectsRange      = fromLights.sizeAffectsRange;
            lights.alphaAffectsIntensity = fromLights.alphaAffectsIntensity;
            
            lights.rangeMultiplier = fromLights.rangeMultiplier;
            lights.range = fromLights.range;
            
            lights.intensityMultiplier = fromLights.intensityMultiplier;
            lights.intensity           = fromLights.intensity;
            
            lights.maxLights             = fromLights.maxLights;
        }

        public static void CopyParticle_Trails(this ParticleSystem toCopy, ParticleSystem from) {
            var trails     = toCopy.trails;
            var fromTrails = from.trails;

            trails.enabled = fromTrails.enabled;
            if(!trails.enabled)
                return;

            trails.mode     = fromTrails.mode;
            
            trails.ratio               = fromTrails.ratio;
            trails.lifetime            = fromTrails.lifetime;
            trails.minVertexDistance   = fromTrails.minVertexDistance;
            trails.worldSpace          = fromTrails.worldSpace;
            trails.dieWithParticles    = fromTrails.dieWithParticles;
            trails.textureMode         = fromTrails.textureMode;
            
            trails.sizeAffectsWidth     = fromTrails.sizeAffectsWidth;
            trails.sizeAffectsLifetime  = fromTrails.sizeAffectsLifetime;
            trails.inheritParticleColor = fromTrails.inheritParticleColor;
            
            trails.colorOverLifetime        = fromTrails.colorOverLifetime;

            trails.widthOverTrail           = fromTrails.widthOverTrail;
            trails.widthOverTrailMultiplier = fromTrails.widthOverTrailMultiplier;
            
            trails.colorOverTrail           = fromTrails.colorOverTrail;
            trails.generateLightingData     = fromTrails.generateLightingData;
            trails.shadowBias               = fromTrails.shadowBias;

            trails.ribbonCount              = fromTrails.ribbonCount;
            trails.splitSubEmitterRibbons   = fromTrails.splitSubEmitterRibbons;
            trails.attachRibbonsToTransform = fromTrails.attachRibbonsToTransform;
        }

        public static void CopyParticle_CustomData(this ParticleSystem toCopy, ParticleSystem from) {
            var colorBySpeed     = toCopy.colorBySpeed;
            var fromColorBySpeed = from.colorBySpeed;

            colorBySpeed.enabled = fromColorBySpeed.enabled;
            if(!colorBySpeed.enabled)
                return;

            colorBySpeed.color = fromColorBySpeed.color;
            colorBySpeed.range = fromColorBySpeed.range;
        }

        public static void CopyParticle_Renderer(this ParticleSystem toCopy, ParticleSystem from) {
            var renderer     = toCopy.GetComponent<ParticleSystemRenderer>();
            var fromRenderer = from.GetComponent<ParticleSystemRenderer>();

            renderer.enabled = fromRenderer.enabled;
            if(!renderer.enabled)
                return;

            renderer.renderMode      = fromRenderer.renderMode;
            renderer.normalDirection = fromRenderer.normalDirection;
            renderer.sharedMaterial        = fromRenderer.sharedMaterial;
            renderer.trailMaterial   = fromRenderer.trailMaterial;
            renderer.sortMode        = fromRenderer.sortMode;
            renderer.sortingFudge    = fromRenderer.sortingFudge;
            renderer.minParticleSize = fromRenderer.minParticleSize;
            renderer.maxParticleSize = fromRenderer.maxParticleSize;
            renderer.alignment       = fromRenderer.alignment;
            renderer.flip            = fromRenderer.flip;
            renderer.allowRoll       = fromRenderer.allowRoll;
            renderer.pivot           = fromRenderer.pivot;
            
            renderer.maskInteraction = fromRenderer.maskInteraction;

            renderer.shadowBias         = fromRenderer.shadowBias;
            renderer.renderingLayerMask = fromRenderer.renderingLayerMask;
        }

    #endregion
    }
}
