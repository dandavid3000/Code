% bai tap 4

clear
clc
close all

% 1. uniform distribution
x = -3 : 0.01 : 5;
a = -1; b = 3;
y = unifpdf(x, a, b);
figure, plot(x,y,'r-');

y = unifcdf(x, a, b);
figure, plot(x,y,'r');

z_unif = unifrnd(a, b, [1, 100]);

% 2. normal distribution
x = -8 : 0.01 : 10;
mu = 1; sig = 2;
y = normpdf(x, mu, sig);
figure, plot(x,y,'r-');

y = normcdf(x, mu, sig);
figure, plot(x,y,'r');

z_norm = normrnd(mu, sig, 1, 100);
