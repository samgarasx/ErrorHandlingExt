using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ErrorHandlingExt
{
    /// <summary>
    /// Result structure.
    /// </summary>
    public struct Result
    {
        /// <summary>
        /// Returns if <see cref="Result"/> is successful or not.
        /// </summary>
        public bool IsSuccess { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Exception error;
        /// <summary>
        /// Returns an <see cref="Exception"/> from failed <see cref="Result"/>.
        /// </summary>
        public Exception Error
        {
            [DebuggerStepThrough]
            get
            {
                if (this.IsSuccess)
                    throw new InvalidOperationException("There is no error for success.");

                return this.error;
            }
        }

        [DebuggerStepThrough]
        private Result(bool isSuccess, Exception error = null)
        {
            this.IsSuccess = isSuccess;
            this.error = error;
        }

        /// <summary>
        /// Creates a successful <see cref="Result"/>.
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static Result FromSuccess()
        {
            return new Result(true);
        }

        /// <summary>
        /// Creates a failed <see cref="Result"/> with given error type.
        /// </summary>
        /// <param name="error">The <see cref="Result"/> error.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static Result FromFailure(Exception error)
        {
            if (error == null)
                throw new ArgumentNullException(nameof(error));

            return new Result(false, error);
        }

        /// <summary>
        /// Creates a <see cref="Result"/> from a method call.
        /// </summary>
        /// <param name="action">The method to call.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static Result From(Action action)
        {
            try
            {
                action();
                return Result.FromSuccess();
            }
            catch (Exception ex)
            {
                return Result.FromFailure(ex);
            }
        }

        /// <summary>
        /// Creates a <see cref="Result"/> from an asynchronous method call.
        /// </summary>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static async Task<Result> FromAsync(Func<Task> func)
        {
            try
            {
                await func().ConfigureAwait(false);
                return Result.FromSuccess();
            }
            catch (Exception ex)
            {
                return Result.FromFailure(ex);
            }
        }
    }

    /// <summary>
    /// Result&lt;T&gt; structure.
    /// </summary>
    /// <typeparam name="T">Type of <see cref="Value"/> property.</typeparam>
    public struct Result<T>
    {
        /// <summary>
        /// Returns if <see cref="Result{T}"/> is successful or not.
        /// </summary>
        public bool IsSuccess { get; private set; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly T value;
        /// <summary>
        /// Returns the value of <see cref="Result{T}"/>.
        /// </summary>
        public T Value
        {
            [DebuggerStepThrough]
            get
            {
                if (!this.IsSuccess)
                    throw new InvalidOperationException("There is no value for failure.");

                return this.value;
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Exception error;
        /// <summary>
        /// Returns an <see cref="Exception"/> from failed <see cref="Result{T}"/>.
        /// </summary>
        public Exception Error
        {
            [DebuggerStepThrough]
            get
            {
                if (this.IsSuccess)
                    throw new InvalidOperationException("There is no error for success.");

                return this.error;
            }
        }

        [DebuggerStepThrough]
        private Result(T value)
        {
            this.IsSuccess = true;
            this.value = value;
            this.error = null;
        }

        [DebuggerStepThrough]
        private Result(Exception error)
        {
            this.IsSuccess = false;
            this.value = default(T);
            this.error = error;
        }

        /// <summary>
        /// Creates a successful <see cref="Result{T}"/> with given value type.
        /// </summary>
        /// <param name="value">The <see cref="Result{T}.Value"/>.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static Result<T> FromSuccess(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return new Result<T>(value);
        }

        /// <summary>
        /// Creates a failed <see cref="Result{T}"/> with given error type.
        /// </summary>
        /// <param name="error">The <see cref="Result{T}"/> error.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static Result<T> FromFailure(Exception error)
        {
            if (error == null)
                throw new ArgumentNullException(nameof(error));

            return new Result<T>(error);
        }

        /// <summary>
        /// Creates a <see cref="Result{T}"/> from a return method call.
        /// </summary>
        /// <param name="func">The method to call.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static Result<T> From(Func<T> func)
        {
            try
            {
                var value = func();
                return Result<T>.FromSuccess(value);
            }
            catch (Exception ex)
            {
                return Result<T>.FromFailure(ex);
            }
        }

        /// <summary>
        /// Creates a <see cref="Result{T}"/> from an asynchronous return method call.
        /// </summary>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static async Task<Result<T>> FromAsync(Func<Task<T>> func)
        {
            try
            {
                var value = await func().ConfigureAwait(false);
                return Result<T>.FromSuccess(value);
            }
            catch (Exception ex)
            {
                return Result<T>.FromFailure(ex);
            }
        }
    }
}
