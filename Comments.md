Issues:
- Code branching based on type seems not really transparent
- Naming conventions are not consistent
- Magic numbers
- Comment sections ar not consistent

Concerns:
1) Logs. Service could return errors list but in the code does not handle it
2) Async calls. Services require network calls. It'll be more efficient to do them in async manner
3) Service calls should be wrapped by try...catch to log network issues
4) Correlation/Trace ID is needed to trace request end-to-end
5) Service call doesn't handle errors. Services are not transparent in this case