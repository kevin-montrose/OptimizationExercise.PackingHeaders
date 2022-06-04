namespace OptimizationExercise.PackingHeaders.Benchmarks
{
    public abstract class ImplBenchmarkBase
    {
        public abstract void GlobalSetup();

        public abstract void Dictionary();

        public abstract void Fields_V1();

        public abstract void Fields_V2();

        public abstract void Arrays_V1();
        public abstract void Arrays_V2();

        public abstract void Packed_V1();

        public abstract void Packed_V2();

        public abstract void Packed_V3();
        public abstract void Packed_V4();

        public virtual void GlobalCleanup() { }
        public virtual void IterationSetup() { }
        public virtual void IterationCleanup() { }
    }
}
