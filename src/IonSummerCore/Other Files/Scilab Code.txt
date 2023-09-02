clc;
clear;

disp('----- WEIGHTED LEAST SQUARES FIT FOR A QUADRATIC POLYNOMIAL -----');

// Introducing the data
disp('1. Introducing the data:');
x=[1.25,2.50,5,10,20,30,40]';
disp('x =');
disp(x);
y=[30151.89357,59543.53432,117599.5737,233857.5235,448633.0221,668863.0719,896864.0854]';
disp('y =');
disp(y);

// Calculating weights
disp('--------------------------------------');
disp('2. Calculating weights:');

// Uncomment the next lines for weights of 1/x
w = zeros(length(x), 1);
for i=1: length(x)
    w(i) = 1/(x(i));
end
disp('Using weights based on 1/x:');
disp('w =');
disp(w);

// Uncomment the next lines for weights of 1/x^2
// w = zeros(length(x), 1);
// for i=1: length(x)
//     w(i) = 1/(x(i)^2);
// end
// disp('Using weights based on 1/x^2:');
// disp('w =');
// disp(w);

// Design matrix creation
disp('--------------------------------------');
disp('3. Creating the Design Matrix D. For a quadratic polynomial y = a + bx + cx^2:');
disp('   - First column: constant term a');
disp('   - Second column: linear term x for coefficient b');
disp('   - Third column: quadratic term x^2 for coefficient c');
D = [ones(length(x), 1), x, x.^2];
disp('D =');
disp(D);

// Transpose of design matrix
disp('--------------------------------------');
disp('4. Calculating the transpose of the Design Matrix for further operations:');
Dt = D';
disp('D'' =');
disp(Dt);

// Weighted matrix creation
disp('--------------------------------------');
disp('5. Creating the diagonal matrix W using calculated weights. Each observation is given a weight based on its reliability:');
W = diag(w);
disp('W =');
disp(W);

// Creating the A matrix
disp('--------------------------------------');
disp('6. Creating matrix A, which is formed by pre-multiplying the design matrix D with its transpose and then with the weight matrix W. Mathematically: A = D''*W*D.');
A = Dt*W*D;
disp('A =');
disp(A);

// Calculating coefficients
disp('--------------------------------------');
disp('7. Calculating the weighted coefficients. The coefficients provide the best fit by minimizing the sum of the weighted squared residuals:');
disp('   Using the equation: coefficients = inv(A) * (D''*W*y)');
coefficients_weighted = inv(A)*(Dt*W*y);
disp('coefficients_weighted =');
disp(coefficients_weighted);

// Displaying the polynomial
disp('--------------------------------------');
disp('Final Quadratic Polynomial obtained from the Weighted Least Squares Fit:');
printf('y = %fx^2 + %fx + %f', coefficients_weighted(3), coefficients_weighted(2), coefficients_weighted(1));
