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
        /// Returns a failed <see cref="Result"/> task from an asynchronous method call.
        /// </summary>
        /// <param name="resultTask">The source <see cref="Result"/>.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result> OnFailure(this Task<Result> resultTask, Func<Task> func)
        {
            Result result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
            {
                try
                {
                    await func().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    return Result.FromFailure(ex);
                }
            }
                
            return result;
        }

        /// <summary>
        /// Returns a failed <see cref="Result"/> task from an asynchronous method call.
        /// </summary>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result> OnFailure(this Task<Result> resultTask, Func<Exception, Task> func)
        {
            Result result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
            {
                try
                {
                    await func(result.Error).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    return Result.FromFailure(ex);
                }
            }

            return result;
        }

        /// <summary>
        /// Returns a failed <see cref="Result"/> task from a synchronous method call.
        /// </summary>
        /// <param name="resultTask">The source <see cref="Result"/>.</param>
        /// <param name="action">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result> OnFailure(this Task<Result> resultTask, Action action)
        {
            Result result = await resultTask.ConfigureAwait(false);

            return result.OnFailure(action);
        }

        /// <summary>
        /// Returns a failed <see cref="Result"/> task from a synchronous method call.
        /// </summary>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="action">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result> OnFailure(this Task<Result> resultTask, Action<Exception> action)
        {
            Result result = await resultTask.ConfigureAwait(false);

            return result.OnFailure(action);
        }

        #endregion

        #region Result<T>

        /// <summary>
        /// Returns a failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TSource>> OnFailure<TSource>(
            this Task<Result<TSource>> resultTask, Func<Task> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
            {
                try
                {
                    await func().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    return Result<TSource>.FromFailure(ex);
                }
            }

            return result;
        }

        /// <summary>
        /// Returns a failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TSource>> OnFailure<TSource>(
            this Task<Result<TSource>> resultTask, Func<Exception, Task> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
            {
                try
                {
                    await func(result.Error).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    return Result<TSource>.FromFailure(ex);
                }
            }

            return result;
        }

        /// <summary>
        /// Returns a failed <see cref="Result{T}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="action">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TSource>> OnFailure<TSource>(
            this Task<Result<TSource>> resultTask, Action action)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            return result.OnFailure(action);
        }

        /// <summary>
        /// Returns a failed <see cref="Result{T}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TSource>> OnFailure<TSource>(
            this Task<Result<TSource>> resultTask, Action<Exception> action)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            return result.OnFailure(action);
        }

        #endregion

        #region Result<T, E>

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TSource, TError>> OnFailure<TSource, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<Task> func, TError error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
            {
                try
                {
                    await func().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    return Result<TSource, TError>.FromFailure(error);
                }
            }

            return result;
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TSource, TError>> OnFailure<TSource, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<TError, Task> func, TError error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
            {
                try
                {
                    await func(result.Error).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    return Result<TSource, TError>.FromFailure(error);
                }
            }

            return result;
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="action">The synchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TSource, TError>> OnFailure<TSource, TError>(
            this Task<Result<TSource, TError>> resultTask, Action action, TError error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            return result.OnFailure(action, error);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="action">The synchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TSource, TError>> OnFailure<TSource, TError>(
            this Task<Result<TSource, TError>> resultTask, Action<TError> action, TError error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            return result.OnFailure(action, error);
        }

        #endregion
    }
}
