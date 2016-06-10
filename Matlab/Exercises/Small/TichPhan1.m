% Bai 2
% Phan 1: tinh dien tich bang tong cac hinh thang

function kq = TichPhan1(f, a, b, delta)

x = a : delta : b; % chia [a,b] thanh cac doan nho voi khoang cach delta
y = f(x); % tinh gia tri tai moi diem chia

dt = (y(1:numel(y)-1)+y(2:end))*delta/2;
kq = sum(dt);

