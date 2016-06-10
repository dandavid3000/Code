function W = classify(X,p1,p2,p3,p4,p5,p6,D_forge,D_genuine)
n = size(D_forge,1);
for i = 1:n
    P_X_forge = mvnpdf(X,p2,p3);    
end
g_forge = P_X_forge * p1;

m = size(D_genuine,1);
for j = 1:m
    P_X_genuine = mvnpdf(X,p5,p6);   
end
g_genuine = P_X_genuine * p4;
for i=1:size(g_forge,1)
  if(g_forge(i) > g_genuine(i))
      W(i,1) = 1;
  else
      W(i,1) = 0;
  end
end
end