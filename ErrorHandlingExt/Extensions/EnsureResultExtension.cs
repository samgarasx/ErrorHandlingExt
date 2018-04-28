using System;

namespace ErrorHandlingExt.Extensions
{
    /// <summary>
    /// Result extension class.
    /// </summary>
    public static partial class ResultExtension
    {
        #region Result

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> with the given error type from a method call.
        /// </summary>
        /// <param name="result">The source <see cref="Result"/>.</param>
        /// <param name="predicate">The method to call.</param>
        /// <param name="error">The <see cref="Result.Error"/>.</param>
        /// <returns></returns>
        public static Result Ensure(this Result result, Func<bool> predicate, Exception error)
        {
            if (!result.IsSuccess)
                return Result.FromFailure(result.Error);

            if (!predicate())
                return Result.FromFailure(error);

            return Result.FromSuccess();
        }

        #endregion

        #region Result<T>

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> with the given error type from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="predicate">The method to call.</param>
        /// <param name="error">The <see cref="Result{T}.Error"/>.</param>
        /// <returns></returns>
        public static Result<TSource> Ensure<TSource>(
            this Result<TSource> result, Func<bool> predicate, Exception error)
        {
            if (!result.IsSuccess)
                return Result<TSource>.FromFailure(result.Error);

            if (!predicate())
                return Result<TSource>.FromFailure(error);

            return Result<TSource>.FromSuccess(result.Value);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> with the given error type from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="predicate">The method to call.</param>
        /// <param name="error">The <see cref="Result{T}.Error"/>.</param>
        /// <returns></returns>
        public static Result<TSource> Ensure<TSource>(
            this Result<TSource> result, Func<TSource, bool> predicate, Exception error)
        {
            if (!result.IsSuccess)
                return Result<TSource>.FromFailure(result.Error);

            if (!predicate(result.Value))
                return Result<TSource>.FromFailure(error);

            return Result<TSource>.FromSuccess(result.Value);
        }

        #endregion
    }
}
