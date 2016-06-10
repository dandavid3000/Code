clc;
clear all;
load bank;
labs = {'Chieu dai','Chieu rong trai','Chieu rong phai','Chieu rong le tren','Chieu rong le duoi','Duong cheo hinh trong'};
for i = 1 : 100
    n(i,1) = {'forge'};
end
for i = 101:200
    n(i,1) = {'genuine'};
end
meas = [forge;genuine];
parallelcoords(meas,'group',n,'labels',labs,'quantile',.25);