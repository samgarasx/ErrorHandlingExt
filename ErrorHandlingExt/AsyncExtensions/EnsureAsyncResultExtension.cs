using System;
using System.Threading.Tasks;

namespace ErrorHandlingExt.Extensions.Tasks
{
    /// <summary>
    /// Asynchronous result extension class.
    /// </summary>
    public static partial class AsyncResultExtension
    {
        #region Result

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> task with the given error from an asynchronous method call.
        /// </summary>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="predicate">The asynchronous method to call.</param>
        /// <param name="error">The <see cref="Result.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result> Ensure(
            this Task<Result> resultTask, Func<Task<bool>> predicate, Exception error)
        {
            Result result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result.FromFailure(result.Error);

            if (!await predicate().ConfigureAwait(false))
                return Result.FromFailure(error);

            return Result.FromSuccess();
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> task with the given error from a synchronous method call.
        /// </summary>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="predicate">The synchronous method to call.</param>
        /// <param name="error">The <see cref="Result.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result> Ensure(this Task<Result> resultTask, Func<bool> predicate, Exception error)
        {
            Result result = await resultTask.ConfigureAwait(false);

            return result.Ensure(predicate, error);
        }

        #endregion

        #region Result<T>

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task with the given error from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="predicate">The asynchronous method to call.</param>
        /// <param name="error">The <see cref="Result{T}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TSource>> Ensure<TSource>(
            this Task<Result<TSource>> resultTask, Func<Task<bool>> predicate, Exception error)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TSource>.FromFailure(result.Error);

            if (!await predicate().ConfigureAwait(false))
                return Result<TSource>.FromFailure(error);

            return Result<TSource>.FromSuccess(result.Value);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task with the given error from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="predicate">The asynchronous method to call.</param>
        /// <param name="error">The <see cref="Result{T}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TSource>> Ensure<TSource>(
            this Task<Result<TSource>> resultTask, Func<TSource, Task<bool>> predicate, Exception error)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TSource>.FromFailure(result.Error);

            if (!await predicate(result.Value).ConfigureAwait(false))
                return Result<TSource>.FromFailure(error);

            return Result<TSource>.FromSuccess(result.Value);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task with the given error from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="predicate">The synchronous method to call.</param>
        /// <param name="error">The <see cref="Result{T}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TSource>> Ensure<TSource>(
            this Task<Result<TSource>> resultTask, Func<bool> predicate, Exception error)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            return result.Ensure(predicate, error);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task with the given error from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="predicate">The synchronous method to call.</param>
        /// <param name="error">The <see cref="Result{T}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TSource>> Ensure<TSource>(
            this Task<Result<TSource>> resultTask, Func<TSource, bool> predicate, Exception error)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            return result.Ensure(predicate, error);
        }

        #endregion
    }
}
