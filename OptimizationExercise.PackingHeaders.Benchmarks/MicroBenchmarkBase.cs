namespace OptimizationExercise.PackingHeaders.Benchmarks
{
    public abstract class MicroBenchmarkBase
    {
        public virtual void IterationSetup() { }

        public abstract void GlobalSetup();
        public abstract void Naive();
        public abstract void Optimized();
    }
}
