
function [p1,p2,p3,p4,p5,p6] = learn(D_forge, D_genuine , P_forge , P_genuine)
n = size(D_forge,1);
mu_forge = zeros(1,6);
for i = 1 : n
    x = D_forge(i,:);
    mu_forge = mu_forge + x;
end
mu_forge = mu_forge / n;

%Tinh phuong sai mau forge
sig_forge = zeros(6,6);
for i = 1 : n
    x = D_forge(i,:);
    sig_forge = sig_forge + ((x - mu_forge)'*(x - mu_forge));
end
sig_forge = sig_forge / (n-1);

%tinh trung binh mau genuine
m = size(D_genuine,1);
mu_genuine = zeros(1,6);
for i = i : m
    x = D_genuine(i,:);
    mu_genuine = mu_genuine + x;
end
mu_genuine = mu_genuine / m;

%Tinh phuong sai mau genuine
sig_genuine = zeros(6,6);
for i = 1 : m
    x = D_genuine(i,:);
    sig_genuine = sig_genuine + ((x - mu_genuine)'*(x - mu_genuine));
end
sig_genuine = sig_genuine / (m-1);

p1= P_forge;
p2= mu_forge;
p3= sig_forge;
p4= P_genuine;
p5= mu_genuine;
p6= sig_genuine;
end

