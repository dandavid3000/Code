% Bai 2
% Phan 3

f = @(x) exp(x).*sin(x); % cach khai bao ham so f(x) ngan gon :-)
a = -5;
b = 5;

% tinh tich phan bang tong dien tich cac hinh thang
delta = 0.001; % try: 0.000001, 0.00000001 va dua ra nhan xet
tp1 = TichPhan1(f, a, b, delta);

% tinh tich phan bang Monte Carlo
n = 100; % try: 10000 1000000 va dua ra nhan xet
tp2 = TichPhan2(f, a, b, n);

% tinh tich phan bang ham cua Matlab
tp3 = quad(f, a, b);

% kiem tra xem tich phan 1 va tich phan 2 khac biet bao nhieu so voi tich
% phan 3
tp1/tp3
tp2/tp3