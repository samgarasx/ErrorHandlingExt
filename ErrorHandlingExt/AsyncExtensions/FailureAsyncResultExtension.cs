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
        /// Returns a failed <see cref="Result"/> task from an asynchronous method call.
        /// </summary>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result> OnFailure(this Task<Result> resultTask, Func<Task<Exception>> func)
        {
            Result result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
            {
                try
                {
                    Exception error = await func().ConfigureAwait(false);

                    return Result.FromFailure(error);
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
        public static async Task<Result> OnFailure(this Task<Result> resultTask, Func<Exception, Task<Exception>> func)
        {
            Result result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
            {
                try
                {
                    Exception error = await func(result.Error).ConfigureAwait(false);

                    return Result.FromFailure(error);
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

        /// <summary>
        /// Returns a failed <see cref="Result"/> task from a synchronous method call.
        /// </summary>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result> OnFailure(this Task<Result> resultTask, Func<Exception> func)
        {
            Result result = await resultTask.ConfigureAwait(false);

            return result.OnFailure(func);
        }

        /// <summary>
        /// Returns a failed <see cref="Result"/> task from a synchronous method call.
        /// </summary>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result> OnFailure(this Task<Result> resultTask, Func<Exception, Exception> func)
        {
            Result result = await resultTask.ConfigureAwait(false);

            return result.OnFailure(func);
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
        /// Returns a failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TSource>> OnFailure<TSource>(
            this Task<Result<TSource>> resultTask, Func<Task<Exception>> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
            {
                try
                {
                    Exception error = await func().ConfigureAwait(false);

                    return Result<TSource>.FromFailure(error);
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
            this Task<Result<TSource>> resultTask, Func<Exception, Task<Exception>> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
            {
                try
                {
                    Exception error = await func(result.Error).ConfigureAwait(false);

                    return Result<TSource>.FromFailure(error);
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
        /// <param name="action">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TSource>> OnFailure<TSource>(
            this Task<Result<TSource>> resultTask, Action<Exception> action)
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
            this Task<Result<TSource>> resultTask, Func<Exception> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            return result.OnFailure(func);
        }

        /// <summary>
        /// Returns a failed <see cref="Result{T}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TSource>> OnFailure<TSource>(
            this Task<Result<TSource>> resultTask, Func<Exception, Exception> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            return result.OnFailure(func);
        }

        #endregion
    }
}
