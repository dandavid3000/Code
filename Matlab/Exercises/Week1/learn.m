function [p1,p2,p3,p4,p5,p6]=learn(D_forge, D_genuine, P_forge, P_genuine)
%xac dinh tham so he phan lop
n = size(D_forge,1);%kich thuoc mau
mu_forge = zeros(1,6);%khoi tao ma tran trung binh mau
mu_genuine = zeros(1,6);

for i = 1 : n 
x = D_forge(i,:);%so chieu cua tap mau dau tien lay ra
y=D_genuine(i,:); 
mu_forge = mu_forge + x;
mu_genuine = mu_genuine + y;
end
mu_forge = mu_forge / n;
mu_genuine = mu_genuine / n;

sig_forge = zeros(6,6);%ma tran hiep phuong sai
for i = 1 : n
x = D_forge(i,:);
%(x-mu_forge)' : ma tran chuyen vi
sig_forge = sig_forge + (x-mu_forge)'*(x-mu_forge);
end
sig_forge = sig_forge / (n-1);

sig_genuine = zeros(6,6);%ma tran hiep phuong sai
for i = 1 : n
x = D_genuine(i,:);
%(x-mu_forge)' : ma tran chuyen vi
sig_genuine = sig_genuine + (x-mu_genuine)'*(x-mu_genuine);
end
sig_genuine = sig_genuine / (n-1);

p1 = mu_forge;
p2 = mu_genuine;
p3 = sig_forge;
p4 = sig_genuine;
p5 = P_forge;
p6 = P_genuine;

