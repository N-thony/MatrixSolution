# Sparse Matrix Representation

## Introduction
This program creates the sparse matrix representation from its traditional representation, and conversely, create the traditional representation from the sparse matrix representation using arrays. 
It includes a sample implementation and a set of xUnit tests to ensure correct functionality.

## Features
- **Conversion:** Facilitates the conversion between traditional dense matrix and sparse matrix representations.
- **Efficiency:** Utilizes array-based structures to optimize memory usage and computational efficiency.
- **Sample Implementation:** Includes a well-documented sample implementation for easy integration and understanding.

### Example
Assuming the input matrix is:
```
0 0 3 0 4            
0 0 5 7 0
0 0 0 0 0
0 2 6 0 0
```

### Output
The resulting sparse matrix representation may look like:
```
0 0 1 1 3 3
2 4 2 3 1 2
3 4 5 7 2 6
```
## Testing

A set of xUnit tests is provided to validate the correct functionality of the sparse matrix representation module. Execute these tests as part of your development process to ensure reliability.
