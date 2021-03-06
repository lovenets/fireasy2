﻿using Fireasy.Common.Subscribe;
using System;
using System.Collections.Generic;

namespace Fireasy.Data.Entity.Subscribes
{
    /// <summary>
    /// 实体持久化的事件订阅器抽象类。
    /// </summary>
    public abstract class EntityPersistentSubscriber : ISubscriber
    {
        /// <summary>
        /// 接收主题信息。
        /// </summary>
        /// <param name="subject"></param>
        void ISubscriber.Accept(ISubject subject)
        {
            var esub = subject as EntityPersistentSubject;
            if (esub == null)
            {
                return;
            }

            switch (esub.EventType)
            {
                case EntityPersistentEventType.BeforeCreate:
                    {
                        if (esub.Argument is EntityEventArgs arg)
                        {
                            OnBeforeCreate(arg.Entity);
                        }
                    }
                    break;
                case EntityPersistentEventType.AfterCreate:
                    {
                        if (esub.Argument is EntityEventArgs arg)
                        {
                            OnAfterCreate(arg.Entity);
                        }
                    }

                    OnCreate(esub.EntityType);
                    break;
                case EntityPersistentEventType.BeforeUpdate:
                    {
                        if (esub.Argument is EntityEventArgs arg)
                        {
                            OnBeforeUpdate(arg.Entity);
                        }
                    }
                    break;
                case EntityPersistentEventType.AfterUpdate:
                    {
                        if (esub.Argument is EntityEventArgs arg)
                        {
                            OnAfterUpdate(arg.Entity);
                        }
                    }

                    OnUpdate(esub.EntityType);
                    break;
                case EntityPersistentEventType.BeforeRemove:
                    {
                        if (esub.Argument is EntityEventArgs arg)
                        {
                            OnBeforeRemove(arg.Entity);
                        }
                    }
                    break;
                case EntityPersistentEventType.AfterRemove:
                    {
                        if (esub.Argument is EntityEventArgs arg)
                        {
                            OnAfterRemove(arg.Entity);
                        }
                    }

                    OnRemove(esub.EntityType);
                    break;
                case EntityPersistentEventType.BeforeBatch:
                    {
                        var arg = esub.Argument as EntitiesArgs;
                        OnBeforeBatch(arg.Entities, arg.OperType);
                    }
                    break;
                case EntityPersistentEventType.AfterBatch:
                    {
                        var arg = esub.Argument as EntitiesArgs;
                        OnAfterBatch(arg.Entities, arg.OperType);

                        switch (arg.OperType)
                        {
                            case EntityPersistentOperater.Create:
                                OnCreate(esub.EntityType);
                                break;
                            case EntityPersistentOperater.Update:
                                OnUpdate(esub.EntityType);
                                break;
                            case EntityPersistentOperater.Remove:
                                OnRemove(esub.EntityType);
                                break;
                        }
                    }

                    break;
            }
        }

        /// <summary>
        /// 用于实体创建之前的通知。
        /// </summary>
        /// <param name="entity">创建的实体对象。</param>
        protected virtual void OnBeforeCreate(IEntity entity)
        {
        }

        /// <summary>
        /// 用于实体创建之后的通知。
        /// </summary>
        /// <param name="entity">创建的实体对象。</param>
        protected virtual void OnAfterCreate(IEntity entity)
        {
        }

        /// <summary>
        /// 用于实体创建之前的通知。
        /// </summary>
        /// <param name="entityType"></param>
        protected virtual void OnCreate(Type entityType)
        {
        }

        /// <summary>
        /// 用于实体更新之前的通知。
        /// </summary>
        /// <param name="entity">更新的实体对象。</param>
        protected virtual void OnBeforeUpdate(IEntity entity)
        {
        }

        /// <summary>
        /// 用于实体更新之后的通知。
        /// </summary>
        /// <param name="entity">更新的实体对象。</param>
        protected virtual void OnAfterUpdate(IEntity entity)
        {
        }

        /// <summary>
        /// 用于实体更新之后的通知。
        /// </summary>
        /// <param name="entityType"></param>
        protected virtual void OnUpdate(Type entityType)
        {
        }

        /// <summary>
        /// 用于实体移除之前的通知。
        /// </summary>
        /// <param name="entity">移除的实体对象。</param>
        protected virtual void OnBeforeRemove(IEntity entity)
        {
        }

        /// <summary>
        /// 用于实体移除之后的通知。
        /// </summary>
        /// <param name="entity">移除的实体对象。</param>
        protected virtual void OnAfterRemove(IEntity entity)
        {
        }

        /// <summary>
        /// 用于实体移除之后的通知。
        /// </summary>
        /// <param name="entityType"></param>
        protected virtual void OnRemove(Type entityType)
        {
        }

        /// <summary>
        /// 用于实体批量处理之前的通知。
        /// </summary>
        /// <param name="entities">批量处理的实体对象。</param>
        /// <param name="operater"></param>
        protected virtual void OnBeforeBatch(IEnumerable<IEntity> entities, EntityPersistentOperater operater)
        {
        }

        /// <summary>
        /// 用于实体批量处理之后的通知。
        /// </summary>
        /// <param name="entities">批量处理的实体对象。</param>
        /// <param name="operater"></param>
        protected virtual void OnAfterBatch(IEnumerable<IEntity> entities, EntityPersistentOperater operater)
        {
        }
    }
}
