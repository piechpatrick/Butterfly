using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.MultiPlatform.Interfaces.Builders
{
    /// <summary>
    /// BuilderBase, TODO: Imporve with DI
    /// </summary>
    /// <typeparam name="TBuilder"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <typeparam name="TBuilderOptions"></typeparam>
    public abstract class BuilderBase<TBuilder, TResult, TBuilderOptions> : IBuilder<TBuilder, TResult>
        where TBuilder : class, IBuilder<TBuilder, TResult>
        where TBuilderOptions : class, IBuilderOptions
    {

        /// <summary>
        /// optioons
        /// </summary>
        protected TBuilderOptions options;

        /// <summary>
        /// BuilderBase
        /// </summary>
        public BuilderBase()
        {
            this.options = Activator.CreateInstance<TBuilderOptions>();
        }

        public TBuilder SetOptions(TBuilderOptions builderOptions)
        {
            this.options = builderOptions;
            return this as TBuilder;
        }


        /// <summary>
        /// Build
        /// </summary>
        /// <returns></returns>
        public abstract TResult Build();
    }
}
